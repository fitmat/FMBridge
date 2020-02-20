# FMBridge

This bridge is used to connect Fitmat to your game.

## Download

Add these files to your project to get started.

[BLEControllerEventHandler](https://github.com/fitmat/FMBridge/blob/master/example/BLEControllerEventHandler.cs) - Add to your scripts

[InitBLE](https://github.com/fitmat/FMBridge/blob/master/example/InitBLE.cs) - Add to your scripts

[FitmatDriver.aar](https://github.com/fitmat/FMBridge/blob/master/FitmatDriver.aar)- Download and copy FitmatDriver.aar and move it to {Unity_Project}\Assets\Plugins\Android

## Example

Visit example folder to check sample project files and usage
[example](https://github.com/fitmat/FMBridge/blob/master/example/)


## Usage

```csharp

//STEP 1 - Download Essentials
//1.1 - Download and copy FitmatDriver.aar and move it to {Unity_Project}\Assets\Plugins\Android
//1.2 - Download and copy InitBLE.cs & BLEControllerEventHandler.cs and move it to {Unity_Project}\Assets\Scripts

//STEP 2 - Call InitBLEFramework() in Awake() with macaddress and gameid
void Awake()
{
	//params ( String macAdress, int GameID )
    InitBLEFramework(macAddress, GameID);  
}
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
