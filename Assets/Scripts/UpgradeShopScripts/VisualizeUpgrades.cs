using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizeUpgrades : MonoBehaviour
{
    private UpgradeManager upgradeManager = new UpgradeManager();
    private CoinManager coinManager = new CoinManager();
    // Start is called before the first frame update
    [SerializeField] private TMPro.TextMeshProUGUI coinCountText;

    [SerializeField] private AudioSource upgradeEffect;

    [SerializeField] private GameObject launcherUpgrade1;
    [SerializeField] private GameObject launcherUpgrade2;
    [SerializeField] private GameObject launcherUpgrade3;

    [SerializeField] private GameObject SolarPanelUpgrade1;
    [SerializeField] private GameObject SolarPanelUpgrade2;
    [SerializeField] private GameObject SolarPanelUpgrade3;

    [SerializeField] private GameObject WeightRedistributionUpgrade1;
    [SerializeField] private GameObject WeightRedistributionUpgrade2;
    [SerializeField] private GameObject WeightRedistributionUpgrade3;

    [SerializeField] private GameObject FuelEfficiencyUpgrade1;
    [SerializeField] private GameObject FuelEfficiencyUpgrade2;
    [SerializeField] private GameObject FuelEfficiencyUpgrade3;

    [SerializeField] private GameObject SoftwareUpdateUpgrade1;
    [SerializeField] private GameObject SoftwareUpdateUpgrade2;
    [SerializeField] private GameObject SoftwareUpdateUpgrade3;

    [SerializeField] private GameObject WealthExpediterUpgrade1;
    [SerializeField] private GameObject WealthExpediterUpgrade2;
    [SerializeField] private GameObject WealthExpediterUpgrade3;

    

    void Start()
    {
        launcherUpgrade1.GetComponent<Image>().enabled = false;
        launcherUpgrade2.GetComponent<Image>().enabled = false;
        launcherUpgrade3.GetComponent<Image>().enabled = false;

        SolarPanelUpgrade1.GetComponent<Image>().enabled = false;
        SolarPanelUpgrade2.GetComponent<Image>().enabled = false;
        SolarPanelUpgrade3.GetComponent<Image>().enabled = false;

        WeightRedistributionUpgrade1.GetComponent<Image>().enabled = false;
        WeightRedistributionUpgrade2.GetComponent<Image>().enabled = false;
        WeightRedistributionUpgrade3.GetComponent<Image>().enabled = false;

        FuelEfficiencyUpgrade1.GetComponent<Image>().enabled = false;
        FuelEfficiencyUpgrade2.GetComponent<Image>().enabled = false;
        FuelEfficiencyUpgrade3.GetComponent<Image>().enabled = false;

        SoftwareUpdateUpgrade1.GetComponent<Image>().enabled = false;
        SoftwareUpdateUpgrade2.GetComponent<Image>().enabled = false;
        SoftwareUpdateUpgrade3.GetComponent<Image>().enabled = false;

        WealthExpediterUpgrade1.GetComponent<Image>().enabled = false;
        WealthExpediterUpgrade2.GetComponent<Image>().enabled = false;
        WealthExpediterUpgrade3.GetComponent<Image>().enabled = false;
        visualizeUpdates();
    }

    public void visualizeUpdates(){
        visualizeSingleUpdate("launchers");
        visualizeSingleUpdate("solarPanels");
        visualizeSingleUpdate("weightRedistributions");
        visualizeSingleUpdate("fuelEfficiency");
        visualizeSingleUpdate("softwareUpdates");
        visualizeSingleUpdate("wealthExpediters");
        updateCoinText();
    }

    public void visualizeSingleUpdate(string upgradeName){
        GameObject square1 = new GameObject();
        GameObject square2 = new GameObject();
        GameObject square3 = new GameObject();
        var upgradeBoolArray = new bool[1];
        switch(upgradeName){
            case "launchers":
                square1 = launcherUpgrade1;
                square2 = launcherUpgrade2;
                square3 = launcherUpgrade3;
                upgradeBoolArray = upgradeManager.getUpgradeArray(upgradeName);
                break;
            case "solarPanels":
                square1 = SolarPanelUpgrade1;
                square2 = SolarPanelUpgrade2;
                square3 = SolarPanelUpgrade3;
                upgradeBoolArray = upgradeManager.getUpgradeArray(upgradeName);
                break;
            case "weightRedistributions":
                square1 = WeightRedistributionUpgrade1;
                square2 = WeightRedistributionUpgrade2;
                square3 = WeightRedistributionUpgrade3;
                upgradeBoolArray = upgradeManager.getUpgradeArray(upgradeName);
                break; 
            case "fuelEfficiency":
                square1 = FuelEfficiencyUpgrade1;
                square2 = FuelEfficiencyUpgrade2;
                square3 = FuelEfficiencyUpgrade3;
                upgradeBoolArray = upgradeManager.getUpgradeArray(upgradeName);
                break;
            case "softwareUpdates":
                square1 = SoftwareUpdateUpgrade1;
                square2 = SoftwareUpdateUpgrade2;
                square3 = SoftwareUpdateUpgrade3;
                upgradeBoolArray = upgradeManager.getUpgradeArray(upgradeName);
                break;
            case "wealthExpediters":
                square1 = WealthExpediterUpgrade1;
                square2 = WealthExpediterUpgrade2;
                square3 = WealthExpediterUpgrade3;
                upgradeBoolArray = upgradeManager.getUpgradeArray(upgradeName);
                break; 
            default:
                return;
        }
        if(upgradeBoolArray[0] == true){
            var spriteRenderer = square1.GetComponent<Image>();
            spriteRenderer.enabled = true;
        }
        if(upgradeBoolArray[1] == true){
            var spriteRenderer = square2.GetComponent<Image>();
            spriteRenderer.enabled = true;
        }
        if(upgradeBoolArray[2   ] == true){
            var spriteRenderer = square3.GetComponent<Image>();
            spriteRenderer.enabled = true;
        }
    }

    public void upgradeLaunchers(){
        bool success = upgradeManager.buyUpgrade("launchers");
        //Debug.Log(success);
        if(success){
            upgradeEffect.Play();
            updateCoinText();
            visualizeSingleUpdate("launchers");
        }
    }

    public void upgradeSolarPanels(){
        bool success = upgradeManager.buyUpgrade("solarPanels");
        //Debug.Log(success);
        if(success){
            upgradeEffect.Play();
            updateCoinText();
            visualizeSingleUpdate("solarPanels");
        }
    }

    public void upgradeWeightRedistributions(){
        bool success = upgradeManager.buyUpgrade("weightRedistributions");
        //Debug.Log(success);
        if(success){
            upgradeEffect.Play();
            updateCoinText();
            visualizeSingleUpdate("weightRedistributions");
        }
    }

    public void upgradeFuelEfficiency(){
        bool success = upgradeManager.buyUpgrade("fuelEfficiency");
        //Debug.Log(success);
        if(success){
            upgradeEffect.Play();
            updateCoinText();
            visualizeSingleUpdate("fuelEfficiency");
        }
    }

    public void upgadeSoftwareUpdates(){
        bool success = upgradeManager.buyUpgrade("softwareUpdates");
        //Debug.Log(success);
        if(success){
            upgradeEffect.Play();
            updateCoinText();
            visualizeSingleUpdate("softwareUpdates");
        }
    }

    public void upgradeWealthExpediters(){
        bool success = upgradeManager.buyUpgrade("wealthExpediters");
        //Debug.Log(success);
        if(success){
            upgradeEffect.Play();
            updateCoinText();
            visualizeSingleUpdate("wealthExpediters");
        }
    }

    public void updateCoinText(){
        coinCountText.text = coinManager.getCoinsCount() + " coins";
    }
}

//var spriteRenderer = launcherUpgrade1.GetComponent<SpriteRenderer>();
//spriteRenderer.color = Color.green;
