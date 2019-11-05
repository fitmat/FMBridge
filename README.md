# FMBridge

This bridge is used to connect Fitmat to your game.

## Download

Add these files to your project to get started.

[BLEControllerEventHandler](https://github.com/fitmat/FMBridge/blob/master/example/BLEControllerEventHandler.cs) - Add to your scripts

[FitmatDriver.aar](https://github.com/fitmat/FMBridge/blob/master/FitmatDriver.aar)- Download and copy FitmatDriver.aar and move it to {Unity_Project}\Assets\Plugins\Android

## Example

Visit example folder to check sample project files and usage
[example](https://github.com/fitmat/FMBridge/blob/master/example/)


## Usage

```csharp

//STEP 1 - Download Essentials
//1.1 - Download and copy FitmatDriver.aar and move it to {Unity_Project}\Assets\Plugins\Android
//1.2 - Download and copy BLEControllerEventHandler.cs and move it to {Unity_Project}\Assets\Scripts

//STEP 2 - Declare FMVariables
static AndroidJavaClass _pluginClass;
static AndroidJavaObject _pluginInstance;
const string driverPathName = "com.fitmat.fitmatdriver.Connection.DeviceControlActivity";
string FMResponseCount = "";

//STEP 3 - Create Unity Callback class
class UnityCallback : AndroidJavaProxy
{
    private System.Action<string> initializeHandler;
    public UnityCallback(System.Action<string> initializeHandlerIn) : base(driverPathName + "$UnityCallback")
    {
        initializeHandler = initializeHandlerIn;
    }

    public void sendMessage(string message)
    {
        Debug.Log("sendMessage: " + message);
        if (initializeHandler != null)
        {
            initializeHandler(message);
        }
    }
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


//STEP 5 - Init Android Class & Objects
public static void InitBLEFramework()
{
       
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
                string macaddress = "A4:34:F1:A5:99:5B";
                int gameId = 2;
                PluginInstance.Call("_setMACAddress", macaddress);
                PluginInstance.Call("_setGameID", gameId);
                PluginInstance.Call("_InitBLEFramework",new object[] { new UnityCallback(callback) });
                
            }
    #endif
}

//STEP 6 - Call InitBLEFramework() in Awake()
void Awake()
{
    InitBLEFramework();
}
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
