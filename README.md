

# FMBridge
FMDriver Version - 0.1.22

This bridge is used to connect Fitmat to your game.

## Whats new in the release
* Updated the reponse for Multiplayer
* FMDriver with new communication protocol (JSON)
* Updated internal file system for better performance and scalability
* Updated the reponse for actions which has properties

## Usage

```csharp

//STEP 1 - Download Essentials
//1.1 - Download and copy FitmatDriver.aar and move it to {Unity_Project}\Assets\Plugins\Android
//1.2 - Download and copy InitBLE.cs & BLEControllerEventHandler.cs and move it to {Unity_Project}\Assets\Scripts

//STEP 2 - Call InitBLEFramework() in Awake() with macaddress and gameid from your controller file
void Awake()
{
  //params ( String macAdress, int GameID )
    InitBLEFramework(macAddress, GameID);  
    //Add this line after Setting MacAddress
    Boolean gameModeSet = PluginInstance.Call("_setGameMode", gameMode); //gameMode = 0 for Multiplayer, 1 for Singleplayer. Also method returns boolean for result
}
```

## Code changes
 1. Change in driverPath in InitBLE.cs (GameLib)
```csharp 
//Change this
const string driverPathName = "com.fitmat.fitmatdriver.Connection.DeviceControlActivity";

//Tothis
const string driverPathName = "com.fitmat.fitmatdriver.Producer.Connection.DeviceControlActivity";
```
 2. Update FMReponse parsing 
```csharp 
//Change this
string FMResponse = InitBLE.PluginClass.CallStatic<string>("_getFMResponse");
Debug.Log("UNITY FMResponse: " + FMResponse);
string[] FMTokens = FMResponse.Split('.');
Debug.Log("UNITY FMTokens: " + FMTokens[0]);

//Tothis
string FMResponse = InitBLE.PluginClass.CallStatic<string>("_getFMResponse");
//TODO JSON Parser - Follow below JSON format and parse accordingly
```
 3. For Multiplayer
```csharp 

//Add this line after Setting MacAddress
PluginInstance.Call("_setGameMode", gameMode); //gameMode = 0 for Multiplayer, 1 for Singleplayer

//For singleplayer calling this method is not necessary 

```
## Game Identifier Table

|   Game Name   |   Game ID   |                Action In the Game             |
|---------------|-------------|-----------------------------------------------|
| Joyfull Jumps |      1      | Running, Running Stopped, Jumping             |
| Yipli Runner  |      2      | Left Move, Right Move, Jumping                |
| Egg Catcher   |      2      | Left Move, Right Move, Jumping                |
| Skater        |      3      | Jump In, Jump Out                             |



## New Protocol for Communication 
```python
######## FOR SINGLE PLAYER ########
{
  "count": 1,                 # Updates every time new action is detected
  "timestamp": 1597237057689, # Time at which response was packaged/created by Driver
  "playerdata": [                      # Array containing player data
    {
      "id": 1,                         # Player ID (For Single-player-1 , Multiplayer it could be 1 or 2 )
      "fmresponse": {
        "action_id": "9D6O",           # Action ID-Unique ID for each action. Refer below table for all action IDs
        "action_name": "Jump",         # Action Name for debugging (Gamers should strictly check action ID)
        "properties": "null"           # Any properties action has - ex. Running could have Step Count, Speed
      }
    }
  ]
}

######## FOR MULTIPLAYER ########
{
  "count": 1,                   
  "timestamp": 1596803141,
  "playerdata": [                # Array containing player data
    {
      "id": 1,                   # Player ID
      "count" : 1,               # Individual players response count 
      "fmresponse": {
        "action_id": "9D6O",
        "action_name": "Jump",
        "properties": "null"
      }
    },
    {
      "id": 2,
      "count" : 5,
      "fmresponse": {
        "action_id": "SWLO",
        "action_name": "Running",
        "properties": "totalStepsCount:2,speed:3.21"
      }
    }
  ]
}
```



## Game Identifier Table

|   Action Name       |   Action ID   | 
|---------------------|-------------|
| Left| 9GO5  |
| Right| 3KWN  |
| Enter| PLW3 |
| Pause| UDH0 |
| Running  | SWLO   |
| Running Stopped | 7RCE  | 
| Jump   | 9D6O |
| Right Move | DMEY | 
| Left Move | 38UF | 
| Jump In | EUOA| 
| Jump Out| QRTY | 




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
