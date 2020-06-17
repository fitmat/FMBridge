

# FMBridge
Version - 0.1.13
This bridge is used to connect Fitmat to your game.

## Whats new in the release

Changes -
 1. New MAT Controls added
 2. Updated "Pause" response count in the driver 
 3. Upadated Skater detection algorithm


## Game Identifier Table

|   Game Name   |   Game ID   |                Action Output                  |
|---------------|-------------|-----------------------------------------------|
| Joyfull Jumps |      1      | Running+23+2.3, Running Stopped, Jumping      |
| Yipli Runner  |      2      | Left Move, Right Move, Jumping                |
| Egg Catcher   |      2      | Left Move, Right Move, Jumping                |
| Skater        |      3      | Jump In, Jump Out                             |




## Download

Add these files to your project to get started.

[BLEControllerEventHandler](https://github.com/fitmat/FMBridge/blob/master/example/BLEControllerEventHandler.cs) - Add to your scripts

[InitBLE](https://github.com/fitmat/FMBridge/blob/master/example/InitBLE.cs) - Add to your scripts


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
