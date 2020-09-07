
## Whats new in the release - v0.1.27
* changes in setGameMode API (Ref. section 1.7.5)


# 1. ReadMe
## 1.1 What is FBridge?
This Fitmat-Bridge (FMBRidge) is used to integrate mat to Game-Lib. It uses AAR (Android Archives) as a dependency.

## 1.2 Prerequisites
Before you get started with the FMBridge, you will require following already being set-up,
* Setup Game-Lib
> Follow this link to setup [Game-Lib](https://docs.google.com/document/d/1AwyTtxGk5f9h4P64m0oODx_-3z-4Dn0qmZ4YlnmbGsQ/edit)

## 1.3 Identifier Tables
### 1. Game Identifier Table 
|   Game Name   |   Game ID   |                Action In the Game             |
|---------------|-------------|-----------------------------------------------|
| Joyfull Jumps |      1      | Running, Running Stopped, Jumping             |
| Yipli Runner  |      2      | Left Move, Right Move, Jumping                |
| Egg Catcher   |      2      | Left Move, Right Move, Jumping                |
| Skater        |      3      | Jump In, Jump Out                             |

### 2. Action Identifier Table 
| Action Name       |   Action ID   | 
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

## 1.4 Installation

* Download and copy FitmatDriver.aar and move it to {Unity_Project}\Assets\Plugins\Android
* Download and copy InitBLE.cs & BLEControllerEventHandler.cs and move it to {Unity_Project}\Assets\Scripts
> Please find all files under [src](https://github.com/fitmat/FMBridge/src) folder

## 1.5 Getting Started
The below methods are called only once throughout game and are used to initialize of the FMBridge & Driver.
1.  Call InitBLEFramework(). Usually call in Awake() with mac-address and game-id 
```csharp
//SOMETHING LIKE THIS
void Awake()
{
    //params ( String macAdress, int GameID )
    InitBLE.InitBLEFramework(macAddress, GameID);      
}
```
> NOTE : Call it only once throughout game

<br>

2. Call setGameMode() to set game mode to SINGLE or MULTI player

```csharp
   //params ( int gameMode)
   //gameMode = 0 - Multiplaye
   //gameMode = 1 - Singleplayer.
   InitBLE.setGameMode(gameMode);
```
> NOTE : Call setGameMode only after setting Mac-Address and Call it only once throughout game


## 1.6 Communication Protocol
This is the JSON response you will receive when ***_getFMResponse*** (Refer section 1.7.6) is called.

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

## 1.7 API                             

**1. getFMDriverVersion**
```csharp
   public static string getFMDriverVersion()
```
Returns Driver's Version number
>**Type**
>Optional

>**Class**
>InItBLE

>**Param**
>None

>**Returns**
> string

------------------------

**2. getGameClusterID**
```csharp
   public static int getGameClusterID()
```
Returns current Game/Cluster ID
>**Type**
>Optional

>**Class**
>InItBLE

>**Param**
>None

>**Returns**
> int
------------------------

**3. getGameMode**
```csharp
   public static int getGameMode()
```
Returns current Game mode
>**Type**
>Optional

>**Class**
>InItBLE

>**Param**
>None 

>**Returns**
> int
------------------------

**4. setGameClusterID**
```csharp
   public static void setGameClusterID(int gameID)
```
Sets current Game/Cluster ID
>**Type**
>Mandatory

>**Class**
>InItBLE

>**Param**
>gameID
>Refer Game Identifier Table for available gameID

>**Returns**
> none
------------------------

**5. setGameMode**
```csharp
    public static void setGameMode(int gameMode)
```
Sets current Game Mode
>**Type**
>Mandatory

>**Class**
>InItBLE

>**Param**
>gameMode 
>0 - MULTI_PLAYER
>1 - SINGLE_PLAYER

>**Returns**
> none
------------------------


**6. _getFMResponse**
```csharp
    InitBLE.PluginClass.CallStatic<string>("_getFMResponse");
```
Returns response from Driver
>**Type**
>Mandatory

>**Class**
>InItBLE

>**Param**
>none

>**Returns**
> JSON Object
> Refer section 1.6
------------------------




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
    bool gameModeSet = PluginInstance.Call("_setGameMode", gameMode); //gameMode = 0 for Multiplayer, 1 for Singleplayer. Also method returns boolean for result
}
```


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)

