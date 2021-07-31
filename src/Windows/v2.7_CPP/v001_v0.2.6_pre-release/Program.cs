using System;
using System.IO.Ports;
using System.Threading;
using System.Runtime.InteropServices;
using UnityEngine;

using UnityEngine.UI;
namespace FMInterface_Win
{
    public class Program : MonoBehaviour
    {
        
        public static SerialPort mySerialPort = null;
        public static int counter = 0;
        public static string FMDATA = "";


        #if UNITY_64
            [DllImport("FMDriver_DLL_x64.dll")]
        #else
            [DllImport("FMDriver_DLL_x86.dll")]
        #endif

        public static extern void _initFMDataProcessing(string _FMData);

      
        void Start()
        {

            InitSerialCommunication();

        }

        public static void InitSerialCommunication()
        {
            /*
            *  ------------------------------
            *   SERIAL COMMUNICATION INIT
            *  ------------------------------
            */

            if (mySerialPort == null)
            {
                mySerialPort = new SerialPort(SetupDiWrap.ComPortNameFromFriendlyNamePrefix("Silicon Labs CP210x USB to UART Bridge")
                                    , 230400
                                    , Parity.None
                                    , 8
                                    , StopBits.One);

                // Open the port for communications
                mySerialPort.Open();
                mySerialPort.ReadTimeout = 50;
            }
            else
            {
                mySerialPort.Close();
                InitSerialCommunication();
            }

        }



        public static string bytesToHex(byte[] bytes, int length)
        {
            char[] hexArray = "0123456789ABCDEF".ToCharArray();
            char[] hexChars = new char[length * 2];
            for (int j = 0; j < length; j++)
            {
                int v = bytes[j] & 0xFF;
                hexChars[j * 2] = hexArray[v >> 4];
                hexChars[j * 2 + 1] = hexArray[v & 0x0F];
                //hexChars[j * 2 + 2] = ' ';
            }
            return new String(hexChars);
        }

        void FixedUpdate()
        {

            try
            {
                byte[] data = new byte[127];
                int bytesRead = Program.mySerialPort.Read(data, 0, data.Length);
                string _message = bytesToHex(data, data.Length);

                Debug.LogError((++Program.counter) + " " + _message);
                _initFMDataProcessing(_message);
            }
            catch (TimeoutException te)
            {
                Debug.LogError("Reading failed...");
            }

        }

        void OnApplicationQuit()
        {
            mySerialPort.Close();
        }

    }

    /// <summary>
    /// The setup di wrap.
    /// </summary>
    public class SetupDiWrap
    {
        public static string ComPortNameFromFriendlyNamePrefix(string friendlyNamePrefix)
        {
            const string className = "Ports";
            Guid[] guids = GetClassGUIDs(className);

            System.Text.RegularExpressions.Regex friendlyNameToComPort =
                new System.Text.RegularExpressions.Regex(@".? \((COM\d+)\)$");  // "..... (COMxxx)" -> COMxxxx
            foreach (Guid guid in guids)
            {
                // We start at the "root" of the device tree and look for all
                // devices that match the interface GUID of a disk
                Guid guidClone = guid;
                IntPtr h = SetupDiGetClassDevs(ref guidClone, 0, IntPtr.Zero, DIGCF_PRESENT | DIGCF_PROFILE);

                if (h.ToInt64() != INVALID_HANDLE_VALUE)
                {
                    int nDevice = 0;
                    while (true)
                    {
                        SP_DEVINFO_DATA da = new SP_DEVINFO_DATA();
                        da.cbSize = Marshal.SizeOf(typeof(SP_DEVINFO_DATA));
                        if (0 == SetupDiEnumDeviceInfo(h, nDevice++, ref da))
                        {
                            break;
                        }

                        uint RegType;
                        byte[] ptrBuf = new byte[BUFFER_SIZE];
                        uint RequiredSize;
                        if (SetupDiGetDeviceRegistryProperty(h, ref da,
                            (uint)SPDRP.FRIENDLYNAME, out RegType, ptrBuf,
                            BUFFER_SIZE, out RequiredSize))
                        {
                            const int utf16terminatorSize_bytes = 2;
                            string friendlyName = System.Text.UnicodeEncoding.Unicode.GetString(ptrBuf, 0, (int)RequiredSize - utf16terminatorSize_bytes);
                            
                            if (!friendlyName.StartsWith(friendlyNamePrefix))
                                continue;

                            if (!friendlyNameToComPort.IsMatch(friendlyName))
                                continue;

                            return friendlyNameToComPort.Match(friendlyName).Groups[1].Value;
                        }
                    } // devices
                    //SetupDiDestroyDeviceInfoList(h);
                }
            } // class guids

            return null;
        }

        /// <summary>
        /// The SP_DEVINFO_DATA structure defines a device instance that is a member of a device information set.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct SP_DEVINFO_DATA
        {
            /// <summary>Size of the structure, in bytes.</summary>
            public int cbSize;
            /// <summary>GUID of the device interface class.</summary>
            public Guid ClassGuid;
            /// <summary>Handle to this device instance.</summary>
            public int DevInst;
            /// <summary>Reserved; do not use.</summary>
            public ulong Reserved;
        }

        const int BUFFER_SIZE = 1024;


        private enum SPDRP
        {
            FRIENDLYNAME = 0x0000000C,
        }

        [DllImport("setupapi.dll", SetLastError = true)]
        static extern bool SetupDiClassGuidsFromName(string ClassName,
                                                     ref Guid ClassGuidArray1stItem, UInt32 ClassGuidArraySize,
                                                     out UInt32 RequiredSize);

        [DllImport("setupapi.dll")]
        private static extern Int32 SetupDiEnumDeviceInfo(IntPtr DeviceInfoSet,
                                                          Int32 MemberIndex, ref SP_DEVINFO_DATA DeviceInterfaceData);


        //p
        [DllImport("setupapi.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SetupDiGetClassDevs(
           ref Guid ClassGuid,
           UInt32 Enumerator,
           IntPtr hwndParent,
           UInt32 Flags
        );

        /// <summary>
        /// The SetupDiGetDeviceRegistryProperty function retrieves the specified device property.
        /// This handle is typically returned by the SetupDiGetClassDevs or SetupDiGetClassDevsEx function.
        /// </summary>
        /// <param Name="DeviceInfoSet">Handle to the device information set that contains the interface and its underlying device.</param>
        /// <param Name="DeviceInfoData">Pointer to an SP_DEVINFO_DATA structure that defines the device instance.</param>
        /// <param Name="Property">Device property to be retrieved. SEE MSDN</param>
        /// <param Name="PropertyRegDataType">Pointer to a variable that receives the registry data Type. This parameter can be NULL.</param>
        /// <param Name="PropertyBuffer">Pointer to a buffer that receives the requested device property.</param>
        /// <param Name="PropertyBufferSize">Size of the buffer, in bytes.</param>
        /// <param Name="RequiredSize">Pointer to a variable that receives the required buffer size, in bytes. This parameter can be NULL.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetupDiGetDeviceRegistryProperty(
            IntPtr DeviceInfoSet,
            ref SP_DEVINFO_DATA DeviceInfoData,
            uint Property,
            out UInt32 PropertyRegDataType,
            byte[] PropertyBuffer,
            uint PropertyBufferSize,
            out UInt32 RequiredSize);


        const int DIGCF_DEFAULT = 0x1;
        const int DIGCF_PRESENT = 0x2;
        const int DIGCF_ALLCLASSES = 0x4;
        const int DIGCF_PROFILE = 0x8;
        const int DIGCF_DEVICEINTERFACE = 0x10;
        const int INVALID_HANDLE_VALUE = -1;

        private static Guid[] GetClassGUIDs(string className)
        {
            UInt32 requiredSize = 0;
            Guid[] guidArray = new Guid[1];

            bool status = SetupDiClassGuidsFromName(className, ref guidArray[0], 1, out requiredSize);
            if (true == status)
            {
                if (1 < requiredSize)
                {
                    guidArray = new Guid[requiredSize];
                    SetupDiClassGuidsFromName(className, ref guidArray[0], requiredSize, out requiredSize);
                }
            }
            else
                throw new System.ComponentModel.Win32Exception();

            return guidArray;
        }
    }



}
