using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataTransferStatic
{
    private static float distanceTraveled { get; set; }
    private static int coinsCollected { get; set; }
    private static float flightDuration { get; set; }
    private static float coinDistanceMultiplier { get; set; }

    public static void resetData(){
        distanceTraveled = 0f;
        coinsCollected = 0;
        flightDuration = 0f;
    }

    public static void setDistanceTraveled(float distance){
        distanceTraveled = distance;
    }

    public static void setCoinsCollected(int coins){
        coinsCollected = coins;
    }

    public static void setFlightDuration(float duration){
        flightDuration = duration;
    }

    public static void setCoinDistanceMultiplier(float multiplier){
        coinDistanceMultiplier = multiplier;
    }

    public static float getDistanceTraveled(){
        return distanceTraveled;
    }

    public static int getCoinsCollected(){
        return coinsCollected;
    }

    public static float getFlightDuration(){
        return flightDuration;
    }

    public static float getCoinDistanceMultiplier(){
        return coinDistanceMultiplier;
    }
    
}
