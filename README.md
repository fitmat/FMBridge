
## Whats new in the release - v0.2.5

* Added Tap Cluster

* Added Touch Cluster and changed distance to 7

* Added reconnection support for PC

* NOTE - Changes only for all PC builds and MM

  

## Whats new in the release - v0.2.4

* Multiple cluster ID for particular player support added.

* CHECK API SECTION FOR NEW API TO SET SAME

* NOTE - All multi-player games need to be in 0.2.4

  

## Whats new in the release - v0.2.3

* Added Codebase for Tree Warior

* Bluetooth reconnection and permission Allow/Deny callback

* MAT Pixel Short issues solved

* NOTE - All games should at least be in 0.2.3

  

## Whats new in the release - v0.2.2

* Removed support for Android TV

  

## Whats new in the release - v0.2.1

* Added Android TV Support

* Check point/API  [1.7.9](https://github.com/fitmat/FMBridge#17-api) on how to set device type for android type

* New Cluster id is required for Tree Warrior, which has Right and Left tap with jump action

* Instead of sending full fmresponse as null, send all fields of fmdata with null values

* Change the MAT Control's logic for the tap. Add relative distance check for check sequence

* NOTE - PC VERSION IS NOT ADDED IN THE CURRENT RELEASE

  

  

----------------------------------------------------------

## TODO
- [x] Cluster Id with One Leg Balance + One Leg Hop (priority : low)

  

------------------------------------------------

  

  

# 1. ReadMe

## 1.1 What is FBridge?

This Fitmat-Bridge (FMBRidge) is used to integrate mat to Game-Lib. It uses AAR (Android Archives) as a dependency.

  

## 1.2 Prerequisites

Before you get started with the FMBridge, you will require following already being set-up,

* Setup Game-Lib

> _Follow this link to setup_ [_Game-Lib_](https://docs.google.com/document/d/1AwyTtxGk5f9h4P64m0oODx_-3z-4Dn0qmZ4YlnmbGsQ/edit)

  

## 1.3 Identifier Tables

### 1. Game Identifier Table

| Game Name  | Game ID| Action Name in the Game |

|------------------------|--------|-------------------------------------------------|

| MAT CONTROLS |  0 | Left, Right, Enter  |

| JOYFULL JUMPS  |  1 | Running, Running Stopped, Jump  |

| METRO RUSH |  6 | Left tap, Right tap, Jump |

| EGG CATCHER  |  6 | Left tap, Right tap, Jump |

| DANCING BALL |  6 | Left tap, Right tap, Jump |

| TREE WARRIOR |  6 | Left tap, Right tap, Jump |

| PUDDLE HOP | 205  | Jump  |

| SKATERS  |  3 | Jump In, Jump Out |

| PENGUIN POP  |  4 | Jump  |

| MAT BEATS  |  5 | Tiles |

| TRAPPED  |  1 | Running, Running Stopped, Jump  |

| TUG OF WAR | 202  | Running, Running Stopped (Running Round)  |

| TUG OF WAR | 203  | Hihn knee |

| TUG OF WAR | 205  | Jump (Jumping Round)  |

| EGG CATCHER MM |  7 | Right touch, Left touch |

| FISH TRAP  |  7 | Right touch, Left touch |

| FRUIT SLICE  | 205  | JUMP  |

| HUNGRY SNAKE |  7 | Right touch, Left touch |

| PINBALL  |  7 | Right touch, Left touch |

| PING PONG  |  7 | Right touch, Left touch |

| TOWER BUILDER  | 205  | JUMP  |

| BOOMERANG  | 205  | JUMP  |

| THE RAFT |  2 | Left Move, Right Move, Jump |

| MONSTER RIVER  | 211  | R Leg Hopping, L Leg Hopping  |

| MULTIPLAYER MAYHEM | 5,0  | Tiles, Mat Controls |

| BASIC1 | 201  | Running, Running Stopped, High Knee, Skier Jack |

| BASIC2 | 202  | Running, Running Stopped  |

| BASIC3 | 203  | High Knee |

| BASIC4 | 204  | Skier Jack  |

| JUMPING  | 205  | Jump  |

| JUMPING JACK | 206  | Jumping Jack  |

| NINJA KICKS  | 207  | Ninja Kick  |

| FORWARD BACKWARD JUMPS | 208  | Forward Jump, Backward Jump |

| HOP SCOTCH | 209  | Hopscotch |

| SIDEWISE JUMPS | 210  | Right Jump, Left Jump |

| ONE LEG HOPPING  | 211  | R Leg Hopping, L Leg Hopping  |

| DIAGONAL JUMPS | 212  | Diagonal Jump |

| STAR JUMPS | 213  | Star Jump |

| CHEST JUMPS  | 214  | Chest Jump  |

| CROSS OVER JACK  | 215  | Crossover JJ  |

| SQUAT AND KICK | 216  | Squat & Kick  |

| 180 JUMPS  | 217  | 180 Jumps |

| SQUAT AND JUMP | 218  | Squat & Jump  |

| MOUNTAIN CLIMBING  | 219  | Mountain Climbing |

| 180 SQUAT  | 220  | 180 Squats  |

| MULE KICK  | 221  | Mule Kick |

| JUMPING JACK AND SQUAT | 222  | Squat & JJ  |

| LATERAL SQUAT JUMP | 223  | Lateral Squats  |

| PLANK JUMP IN  | 224  | Plank Jump Ins  |

| LUNGES RUN | 225  | Lunges Run  |

| BURPEES  | 226  | Burpee  |

| MALASANA | 227  | Malasana  |

| SINGLE LEG BALANCE | 228  | Balance Started, Balance Stopped  |

| 3 LEG DOG  | 229  | 3 Leg Dog |

| BANARSANA  | 230  | Banarsana |

| AEROPLANE POSE | 231  | Aeroplane pose  |

| VIKRASANA  | 232  | Vikrasana |

| BASIC PLANK  | 233  | Basic plank |

| ARDHA CHANDRASANA  | 234  | Ardha Chandrasana |

| PLANK ONE ARM HOLD | 235  | 1-Arm Started, 1-Arm Stopped  |

  

### 2. Action Identifier Table

| Action Name | Action ID | Properties |

|-------------------|---------------|----------------|

| Left  | 9GO5  |  -  |

| Right | 3KWN  |  -  |

| Enter | PLW3  |  -  |

| Pause | UDH0  |  -  |

| Running | SWLO  | totalStepsCount, speed  |

| Running Stopped | 7RCE  |  -  |

| Jump  | 9D6O  |  -  |

| Right Move  | DMEY  |  -  |

| Left Move | 38UF  |  -  |

| Jump In | EUOA  |  -  |

| Jump Out  | QRTY  |  -  |

| Jumping Jack  | 99XR  |  -  |

| Skier Jack  | NWCH  |  -  |

| Crossover JJ  | VUFO  |  -  |

| Lunges Run  | 386I  |  -  |

| Mountain Climbing | BGM4  |  -  |

| Plank Started | 58GH  |  -  |

| Plank Stopped | 0DLA  |  -  |

| Mule Kick | WBUT  |  -  |

| R Leg Hopping | 3DIN  |  -  |

| L Leg Hopping | 3DI1  |  -  |

| Burpee  | FN1S  |  -  |

| 180 Jumps | V56G  |  -  |

| Diagonal Jump | 6JJR  |  -  |

| Forward Jump  | UJ3J  |  -  |

| Backward Jump | U10J  |  -  |

| Right Jump  | B8X7  |  -  |

| Left Jump | 18X7  |  -  |

| Star Jump | LPM0  |  -  |

| Chest Jump  | JASL  |  -  |

| Hopscotch | U8W2  |  -  |

| Balance Started | UWC6  |  -  |

| Balance Stopped | 1WC1  |  -  |

| 1-Arm Started | ISJD  |  -  |

| 1-Arm Stopped | EJ02  |  -  |

| Ninja Kick  | 90DM  |  -  |

| High Knee | HXCQ  |  -  |

| 180 Squats  | FYN1  |  -  |

| Squat & Jump  | 6CTM  |  -  |

| Squat & Kick  | E0CB  |  -  |

| Squats  | OYMP  |  -  |

| Squat & JJ  | O12U  |  -  |

| Lateral Squats  | X5IW  |  -  |

| Plank Jump Ins  | WBTW  |  -  |

| 3 Leg Dog | 8G3J  |  -  |

| Banarsana | UWHX  |  -  |

| Aeroplane pose  | Not Developed |  -  |

| Vikrasana | Not Developed |  -  |

| Ardha Chandrasana | 3JCQ  |  -  |

| Malasana  | 3J11  |  -  |

| Tiles | TIL3  | X1, x2, x3, x4 |

| Right Tap | 3L1N |  -  |

| Left Tap | 9015 |  -  |

| Right Touch | AL0N |  -  |

| Left Touch | A075 |  -  |

  

## 1.4 Installation

#### *_Android_*

* Download and copy FitmatDriver.aar and move it to {Unity_Project}\Assets\Plugins\Android

* Download and copy InitBLE.cs & BLEControllerEventHandler.cs and move it to {Unity_Project}\Assets\Scripts

> _Please find all files under_ [_src_](https://github.com/fitmat/FMBridge/src) _folder_

  

#### *_Windows_*

* Download and copy PCFitmatDriver folder and move it to {Unity_Project}\Assets\Plugins\Windows

* Download and copy InitBLE.cs and move it to {Unity_Project}\Assets\Scripts

> _Please find all files under_ [_src_](https://github.com/fitmat/FMBridge/src) _folder_

  

## 1.5 Getting Started

#### *_Android_*

The below methods are used to initialize of the FMBridge & Driver.

1.  Call InitBLEFramework(). Usually call in Awake() with mac-address and game-id

```csharp

//SOMETHING LIKE THIS

void Awake()

{

//params ( String macAdress, int GameID )

InitBLE.InitBLEFramework(macAddress, GameID);

}

```

> _NOTE : Call it only once throughout game_

  

<br>

  

2. Call setGameMode() to set game mode to SINGLE or MULTI player

  

```csharp

//params ( int gameMode)

//gameMode = 0 - Multiplayer

//gameMode = 1 - Singleplayer

InitBLE.setGameMode(gameMode);

```

> _NOTE : Call setGameMode-Multiplayer only after setting game mode for SINGLE PLAYER and it can be called multiple times_

  

  

#### *_Windows_*

1.  Call InitPCFramework(). Usually call in Awake() with game-id

```csharp

//SOMETHING LIKE THIS

void Awake()

{

//params (int GameID )

InitBLE.InitPCFramework(GameID);

}

```

  

  

## 1.6 Communication Protocol

This is the JSON response you will receive when *****__getFMResponse_***** (Refer section 1.7.6) is called.

  

```python

######## FOR SINGLE PLAYER ########

{

"count": 1, # Updates every time new action is detected

"timestamp": 1597237057689, # Time at which response was packaged/created by Driver

"playerdata": [  # Array containing player data

{

"id": 1, # Player ID (For Single-player-1 , Multiplayer it could be 1 or 2 )

"fmresponse": {

"action_id": "9D6O", # Action ID-Unique ID for each action. Refer below table for all action IDs

"action_name": "Jump", # Action Name for debugging (Gamers should strictly check action ID)

"properties": "null" # Any properties action has - ex. Running could have Step Count, Speed

}

}

]

}

  

######## FOR MULTIPLAYER ########

{

"count": 1,

"timestamp": 1596803141,

"playerdata": [  # Array containing player data

{

"id": 1, # Player ID

"count" : 1, # Individual players response count

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

  

****1. getFMDriverVersion****

```csharp

public static string getFMDriverVersion()

```

Returns Driver's Version number

>****_Type_****

>_Optional_

  

>****_Class_****

>_InItBLE_

  

>****_Param_****

>_None_

  

>****_Returns_****

> _string_

  

------------------------

  

****2. getGameClusterID****

```csharp

public static int getGameClusterID()

```

Returns current Game/Cluster ID

>****_Type_****

>_Optional_

  

>****_Class_****

>_InItBLE_

  

>****_Param_****

>_None_

  

>****_Returns_****

> _int_

------------------------

  

****3. getGameMode****

```csharp

public static int getGameMode()

```

Returns current Game mode

>****_Type_****

>_Optional_

  

>****_Class_****

>_InItBLE_

  

>****_Param_****

>_None_

  

>****_Returns_****

> _int_

------------------------

  

****4. setGameClusterID****

```csharp

public static void setGameClusterID(int gameID)

```

Sets current Game/Cluster ID

>****_Type_****

>_Mandatory_

  

>****_Class_****

>_InItBLE_

  

>****_Param_****

>_gameID_

>_Refer Game Identifier Table for available gameID_

  

>****_Returns_****

> _none_

------------------------

  

****5. setGameMode****

```csharp

public static void setGameMode(int gameMode)

```

Sets current Game Mode

>****_Type_****

>_Mandatory_

  

>****_Class_****

>_InItBLE_

  

>****_Param_****

>_gameMode_

>_0 - MULTI_PLAYER_

>_1 - SINGLE_PLAYER_

  

>****_Returns_****

> _none_

------------------------

  

  

****6. _getFMResponse****

```csharp

InitBLE.PluginClass.CallStatic<string>("_getFMResponse");

```

Returns response from Driver

>****_Type_****

>_Mandatory_

  

>****_Class_****

>_InItBLE_

  

>****_Param_****

>_none_

  

>****_Returns_****

> _JSON Object_

> _Refer section 1.6_

------------------------

  

  

****7. _IsDeviceConnected****

```csharp

public int _IsDeviceConnected()

```

****ONLY FOR WINDOWS****

Returns if USB is connected to PC

>****_Type_****

>_Optional_

  

>****_Class_****

>_DeviceControlActivity_

  

>****_Param_****

>_None_

  

>****_Returns_****

> _int ( 0- Not connected | 1-Connected )_

------------------------

  

  

****8. _reconnectDevice****

```csharp

public void _reconnectDevice()

```

****ONLY FOR WINDOWS****

Reconnects Driver to Mat

>****_Type_****

>_Optional_

  

>****_Class_****

>_DeviceControlActivity_

  

>****_Param_****

>_None_

  

>****_Returns_****

> _None_

------------------------

  

****9. _setConnectionType****

```csharp

public static void _setConnectionType(string Type)

```

****ONLY FOR ANDROID TV****

Sets current Connection Type

>****_Type_****

>_Mandatory for Android TV | Not for PC/Mobile_

  

>****_Class_****

>_InItBLE_

  

>****_Param_****

>_Type_

>_"USB" or "BLE"_

  

>****_Returns_****

> _none_

------------------------

****10. getGameClusterID****

```csharp

public static int getGameClusterID(int playerID)

```

Returns current Game/Cluster ID for a particular player. THIS WORKS ONLY IF YOU ARE IN MULTI PLAYER. SETGAMEMODE FIRST TO GET ACCESS OF THIS API

>****_Type_****

>_Optional_

  

>****_Class_****

>_InItBLE_

  

>****_Param_****

>_None_

  

>****_Returns_****

> _int_

------------------------

  

****11. setGameClusterID****

```csharp

public static void setGameClusterID(int p1_gameID, int p2_gameID)

```

Sets current Game/Cluster ID for a particular player. THIS WORKS ONLY IF YOU ARE IN MULTI PLAYER. SETGAMEMODE FIRST TO GET ACCESS OF THIS API

>****_Type_****

>_Mandatory_

  

>****_Class_****

>_InItBLE_

  

>****_Param_****

>_p1_gameID_

>_Sets cluster id for player-1. Refer Game Identifier Table for available gameID_

>_p2_gameID_

>_Sets cluster id for player-2. Refer Game Identifier Table for available gameID_

  

>****_Returns_****

> _none_

------------------------

  

## 1.8 Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

  

Please make sure to update tests as appropriate.

  

## 1.9 License

[MIT](https://choosealicense.com/licenses/mit/)