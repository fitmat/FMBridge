using System;
using com.fitmat.fitmatdriver.Producer.Connection;
using UnityEngine;

public class USB
{
    public static void InitUSBFramework()
    {
        DeviceControlActivity.InitPCFramework(0);
    }

    public static string GetFMResponse()
    {
        return DeviceControlActivity._getFMResponse();
    }  

    public static string getMatConnectionStatus()
    {
       return DeviceControlActivity._IsDeviceConnected() == 1 ? "CONNECTED" : "DISCONNECTED";
    }

    public static void reconnectMat()
    {
        DeviceControlActivity._reconnectDevice();
    }

    public static void setGameMode(int gameMode)
    {
        DeviceControlActivity._setGameMode(gameMode);
    }

    public static int getGameMode()
    {
        return DeviceControlActivity._getGameMode();
    }

    public static void setGameClusterID(int gameID)
    {
        DeviceControlActivity._setGameID(gameID);
    }

    public static void setGameClusterID(int P1_gameID, int P2_gameID)
    {
        //TODO
        //DeviceControlActivity._setGameID(P1_gameID, P2_gameID);
    }

    public static int getGameClusterID()
    {
        return DeviceControlActivity._getGameID();
    }

    public static int getGameClusterID(int playerID)
    {
        //TODO
        //return DeviceControlActivity._getDriverVersion();
        return 1000;
    }

    public static string getFMDriverVersion()
    {
        return DeviceControlActivity._getDriverVersion();
    }
    


}
