using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance { get; private set; }

    [SerializeField] private static bool[] launchers = new bool[] {false,false,false};
    [SerializeField] private static bool[] solarPanels = new bool[] {false,false,false};
    [SerializeField] private static bool[] weightRedistributions = new bool[] {false,false,false};
    [SerializeField] private static bool[] navigationControls = new bool[] {false,false,false};
    [SerializeField] private static bool[] softwareUpdates = new bool[] {false,false,false};
    [SerializeField] private static bool[] wealthExpediters = new bool[] {false,false,false};

    [SerializeField] private static int[] launchersPrices = new int[] {100,300,500};
    [SerializeField] private static int[] solarPanelsPrices = new int[] {100,300,500};
    [SerializeField] private static int[] weightRedistributionsPrices = new int[] {100,300,500};
    [SerializeField] private static int[] navigationControlsPrices = new int[] {100,300,500};
    [SerializeField] private static int[] softwareUpdatesPrices = new int[] {100,300,500};
    [SerializeField] private static int[] wealthExpeditersPrices = new int[] {100,300,500};

    private CoinManager coinManager = new CoinManager();
     // If there is an instance, and it's not me, delete myself.
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public bool buyUpgrade(string upgradeName){
        bool[] upgradeType = new bool[0];
        int[] upgradePrices = new int[0];
        switch(upgradeName){
            case "launchers":
                upgradeType = launchers;
                upgradePrices = launchersPrices;
                break;
            case "solarPanels":
                upgradeType = solarPanels;
                upgradePrices = solarPanelsPrices;
                break;
            case "weightRedistributions":
                upgradeType = weightRedistributions;
                upgradePrices = weightRedistributionsPrices;
                break; 
            case "navigationControls":
                upgradeType = navigationControls;
                upgradePrices = navigationControlsPrices;
                break;
            case "softwareUpdates":
                upgradeType = softwareUpdates;
                upgradePrices = softwareUpdatesPrices;
                break;
            case "wealthExpediters":
                upgradeType = wealthExpediters;
                upgradePrices = wealthExpeditersPrices;
                break; 
            default:
                return false;
        }
        if(upgradeType[0] == false && coinManager.ableToSpend(upgradePrices[0])){
            coinManager.removeCoins(upgradePrices[0]);
            upgradeType[0] = true;
            Debug.Log(coinManager.getCoinsCount());
            return true;
        }
        else if(upgradeType[1] == false && coinManager.ableToSpend(upgradePrices[1])){
            coinManager.removeCoins(upgradePrices[1]);
            upgradeType[1] = true;
            Debug.Log(coinManager.getCoinsCount());
            return true;
        }
        else if(upgradeType[2] == false && coinManager.ableToSpend(upgradePrices[2])){
            coinManager.removeCoins(upgradePrices[2]);
            upgradeType[2] = true;
            Debug.Log(coinManager.getCoinsCount());
            return true;
        }
        return false;
    }

    public bool[] getUpgradeArray(string upgradeName){
        switch(upgradeName){
            case "launchers":
                return launchers;
                break;
            case "solarPanels":
                return solarPanels;
                break;
            case "weightRedistributions":
                return weightRedistributions;
                break; 
            case "navigationControls":
                return navigationControls;
                break;
            case "softwareUpdates":
                return softwareUpdates;
                break;
            case "wealthExpediters":
                return wealthExpediters;
                break; 
            default:
                return null;
        }
    }

    
}
