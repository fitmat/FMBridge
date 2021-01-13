using System;
using UnityEngine;
public class FMBridge
{
  

    /*
    * Function:  initFMBridge 
    * --------------------
    * @summary intialises connection of game with mat. Called when connecting by BLE 
    * 
    * @param _clusterId    
    *   Set cluster ID  from the Game Identifier Table (https://github.com/fitmat/FMBridge#1-game-identifier-table)
    *   
    * @param _macAddress    
    *   Bluetooth mac address in string with all caps and colon separted format. ex: 00:11:22:33:FF:EE
    *       
    * @return bool
    *   Initiation success (true) or failed (false)
    */
    public static bool InitFMBridge(string _macAddress)
    {
        try
        {
            #if UNITY_STANDALONE
                return false;    
            #endif
            BLE.InitBLEFramework(_macAddress);
            return true;
        }
        catch (Exception e)
        {
            Debug.Log("Exception in InitFMBridge(_macAddress) : " + e.Message);
            return false;
        }
    }



    /*
    * Function:  initFMBridge 
    * --------------------
    * @summary intialises connection of game with mat. Called when connecting by USB 
    *        
    * @return bool
    *   Initiation success (true) or failed (false)
    */
    public static bool InitFMBridge()
    {
        try
        {
            #if UNITY_STANDALONE
                return false;    
            #endif
                USB.InitUSBFramework();
            return true;
        }
        catch (Exception e)
        {
            Debug.Log("Exception in InitFMBridge() : " + e.Message);
            return false;
        }
    }



    /*
    * Function:  reconnectMat 
    * --------------------
    * @summary Used to reconnect the mat using existing connection specification
    *        
    * @return void
    */
    public static void ReconnectMat()
    { 
        try
        {
            #if UNITY_ANDROID
                BLE.reconnectMat();
            #elif UNITY_STANDALONE_WIN
                //TODO
                DeviceControlActivity._reconnectDevice();
            #endif
        }
        catch (Exception e)
        {
            Debug.Log("Exception in reconnectMat() : " + e.Message);
        }
    }



    /*
    * Function:  GetFMResponse 
    * --------------------
    * @summary This funciton gets response of actions from MAT
    *        
    * @return string
    *   FMResponse Packet Object - JSON Type
    */
    public static string GetFMResponse()
    {
        try
        {
            #if UNITY_ANDROID
                return BLE.GetFMResponse();
            #elif UNITY_STANDALONE_WIN || UNITY_EDITOR
                //TODO
                return DeviceControlActivity._getFMResponse();
            #endif
        }
        catch (Exception e)
        {
            Debug.Log("Exception in GetFMResponse() : " + e.Message);
            return "error";
        }
    }



    /*
    * Function:  setGameMode 
    * --------------------
    * @summary Changes game mode based on params passed.
    * 
    * @param 
    *   1 - Single Player
    *   0 - Multi-Player
    *        
    * @return void
    *   
    */
    public static void SetGameMode(int _gameMode)
    {
        try
        {
            #if UNITY_ANDROID
                BLE.setGameMode(_gameMode);
            #elif UNITY_STANDALONE_WIN || UNITY_EDITOR
                //TODO
                DeviceControlActivity._setGameMode(gameMode);
            #endif
        }
        catch (Exception e)
        {
            Debug.Log("Exception in SetGameMode() : " + e.Message);
        }
    }



    /*
    * Function:  GetGameMode 
    * --------------------
    * @summary Gets game mode currently set.
    * 
    *        
    * @return int
    *  0 - Single Player
    *  1 - Multiplayer
    *   
    */
    public static int GetGameMode()
    {
        try
        {
            #if UNITY_ANDROID
                return BLE.getGameMode();
            #elif UNITY_STANDALONE_WIN || UNITY_EDITOR
                //TODO
                return DeviceControlActivity._getGameMode();
            #endif
        }
        catch (Exception e)
        {
            Debug.Log("Exception in GetGameMode() : " + e.Message);
            return 1000;//1000 will be flagged as an invalid GameId on game side.
        }
    }


    /*
    * Function:  SetClusterID 
    * --------------------
    * @summary sets cluster ID to detect particular set of actions
    * 
    * @params int
    *   _clusterID - Refer to the game identifier table on FMBridge readme page
    *
    * @return void
    *   
    */
    public static void SetClusterID(int _clusterID)
    {
        try
        {
            #if UNITY_ANDROID
                BLE.setGameClusterID(_clusterID);
            #elif UNITY_STANDALONE_WIN || UNITY_EDITOR
                //TODO 
                DeviceControlActivity._setGameID(clusterID);
            #endif
        }
        catch (Exception e)
        {
            Debug.Log("Exception in SetClusterID() : " + e.Message);
        }
    }


    /*
    * Function:  SetClusterID 
    * --------------------
    * @summary sets cluster ID for multiple player to detect particular set of actions
    * 
    * @params int
    *   _P1_gameID - cluster id for player 1 on the mat
    *   _P2_gameID - cluster id for player 2 on the mat
    *
    * @return void
    *   
    */
    public static void SetClusterID(int _P1_gameID, int _P2_gameID)
    {
        try
        {
            #if UNITY_ANDROID
                 BLE.setGameClusterID(_P1_gameID, _P2_gameID);
            #elif UNITY_STANDALONE_WIN || UNITY_EDITOR
                //TODO 
                DeviceControlActivity._setGameID(P1_gameID, P2_gameID);
            #endif
        }
        catch (Exception e)
        {
            Debug.Log("Exception in SetClusterID() : " + e.Message);
        }
    }


    /*
    * Function:  GetClusterID 
    * --------------------
    * @summary get cluster ID 
    *
    * @return int
    *   cluster id
    */
    public static int GetClusterID()
    {
        try
        {
            #if UNITY_ANDROID
                return BLE.getGameClusterID();
            #elif UNITY_STANDALONE_WIN || UNITY_EDITOR
                //TODO
                return DeviceControlActivity._getGameID();
            #endif
        }
        catch (Exception e)
        {
            Debug.Log("Exception in GetClusterID() : " + e.Message);
            return 1000;//1000 will be flagged as an invalid GameId on game side.
        }
    }


    /*
    * Function:  GetClusterID 
    * --------------------
    * @summary get cluster ID based on player ID. For multiplayer game
    *
    * @return int
    *   cluster id
    */
    public static int GetClusterID(int _playerID)
    {
        try
        {
            #if UNITY_ANDROID
                return BLE.getGameClusterID(_playerID);
            #elif UNITY_STANDALONE_WIN || UNITY_EDITOR
                //TODO 
                return DeviceControlActivity._getGameID(playerID);
            #endif
        }
        catch (Exception e)
        {
            Debug.Log("Exception in GetClusterID() : " + e.Message);
            return 1000;//1000 will be flagged as an invalid GameId on game side.
        }
    }

    /*
    * Function:  GetFMDriverVersion 
    * --------------------
    * @summary get FM Driver version
    *
    * @return string
    *   version
    */
    public static string GetFMDriverVersion()
    {
        try
        {
            #if UNITY_ANDROID
                return BLE.getFMDriverVersion();
            #elif UNITY_STANDALONE_WIN || UNITY_EDITOR
                //TODO
                return DeviceControlActivity._getDriverVersion();
            #endif
        }
        catch (Exception exp)
        {
            Debug.Log("Exception in GetFMDriverVersion()" + exp.Message);
            return null;
        }
    }

    /*
    * Function:  GetMatConnectionStatus 
    * --------------------
    * @summary Returns multiple status of mat connection
    *
    * @return string
    *   CONNECTED
    *   DISCONNECTED
    *   ERROR
    *   CONNECTION LOST
    *   
    */
    public static string GetMatConnectionStatus()
    {
        try
        {
            #if UNITY_ANDROID
                return BLE.getMatConnectionStatus();
            #elif UNITY_STANDALONE_WIN || UNITY_EDITOR
                return DeviceControlActivity._IsDeviceConnected() == 1 ? "CONNECTED" : "DISCONNECTED";
            #endif
        }
        catch (Exception e)
        {
            Debug.Log("Exception in getMatConnectionStatus() : " + e.Message);
        }
        return "disconnected";
    }

}