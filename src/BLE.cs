using System;
using UnityEngine;
public class BLE
{
    static AndroidJavaClass _pluginClass;
    static AndroidJavaObject _pluginInstance;
    const string driverPathName = "com.fitmat.fitmatdriver.Producer.Connection.DeviceControlActivity";
    static string BLEStatus = "";
    //STEP 3 - Create Unity Callback class
    class UnityCallback : AndroidJavaProxy
    {
        private Action<string> initializeHandler;
        public UnityCallback(Action<string> initializeHandlerIn) : base(driverPathName + "$UnityCallback")
        {
            initializeHandler = initializeHandlerIn;
        }
        public void sendMessage(string message)
        {
            Debug.Log("sendMessage: " + message);
            if (message == "connected")
            {
                BLEStatus = "CONNECTED";
            }
            if (message == "disconnected")
            {
                BLEStatus = "DISCONNECTED";
            }
            if (message == "lost")
            {
                BLEStatus = "CONNECTION LOST";
            }
            if (message.Contains("error"))
            {
                BLEStatus = "ERROR";
            }
            initializeHandler?.Invoke(message);
        }
    }

    public static string GetFMResponse()
    {
        return PluginClass.CallStatic<string>("_getFMResponse");
    }

    //STEP 4 - Init Android Class & Objects
    public static AndroidJavaClass PluginClass
    {
        get
        {
            if (_pluginClass == null)
            {
                _pluginClass = new AndroidJavaClass(driverPathName);
            }
            return _pluginClass;
        }
    }
    public static AndroidJavaObject PluginInstance
    {
        get
        {
            if (_pluginInstance == null)
            {
                AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
                _pluginInstance = PluginClass.CallStatic<AndroidJavaObject>("getInstance", activity);
            }
            return _pluginInstance;
        }
    }


    public static string getMatConnectionStatus()
    {
        return BLEStatus;
    }


    public static void reconnectMat()
    {
        System.Action<string> callback = ((string message) =>
        {
            BLEFramework.Unity.BLEControllerEventHandler.OnBleDidInitialize(message);
        });
        PluginInstance.Call("_InitBLEFramework", new object[] { new UnityCallback(callback) });
    }

    //STEP 5 - Init Android Class & Objects
    public static void InitBLEFramework(string macaddress)
    {
        Debug.Log("init_ble: setting macaddress & gameID - " + macaddress);
#if UNITY_IPHONE
                // Now we check that it's actually an iOS device/simulator, not the Unity Player. You only get plugins on the actual device or iOS Simulator.
                if (Application.platform == RuntimePlatform.IPhonePlayer)
                {
                    _InitBLEFramework();
                }
#elif UNITY_ANDROID
        if (Application.platform == RuntimePlatform.Android)
        {
            System.Action<string> callback = ((string message) =>
            {
                BLEFramework.Unity.BLEControllerEventHandler.OnBleDidInitialize(message);
            });

            PluginInstance.Call("_setMACAddress", macaddress);;
            PluginInstance.Call("_InitBLEFramework", new object[] { new UnityCallback(callback) });

        }
#endif
    }


    public static void setGameMode(int gameMode)
    {
        PluginInstance.Call("_setGameMode", gameMode);
    }

    public static int getGameMode()
    {
        return PluginInstance.CallStatic<int>("_getGameMode");
    }


    public static void setGameClusterID(int gameID)
    {
        PluginInstance.Call("_setGameID", gameID);
    }

    public static void setGameClusterID(int P1_gameID, int P2_gameID)
    {
       PluginInstance.Call("_setGameID", P1_gameID, P2_gameID);
    }


    public static int getGameClusterID()
    {
        return PluginInstance.CallStatic<int>("_getGameID");
    }

    public static int getGameClusterID(int playerID)
    {
        return PluginInstance.CallStatic<int>("_getGameID", playerID);
    }

    public static string getFMDriverVersion()
    {
        return PluginInstance.CallStatic<string>("_getDriverVersion");
    }

    public static void setConnectionType(string type)
    {
        /*
            - Strickly should be used for Android TV
            - Optional for Android
            - Not required for PC

            @Params type : USB or BLE
        */

        PluginInstance.Call("_setConnectionType", type);
    }


}