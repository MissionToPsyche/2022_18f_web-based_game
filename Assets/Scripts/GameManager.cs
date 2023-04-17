using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    public float boost_speed = 20f;
    public float move_speed = 15f;
    public float launch_speed = 50f;
    public float maxFuel = 100f;
    public float fuelBurnRate = 10f;
    public float collisionReduction = 1f;
    public float coinDistanceMultiplier = 1f;
    public int coinValue = 10;

    public static bool runStart = true;
    public static bool atShop = false;
    public bool runEnd = false;

    private UpgradeManager upgradeManager = new UpgradeManager();
    private CoinManager coinManager = new CoinManager();
    TransitionLoader loader;


    [SerializeField] private Slider fuelSlider;

    private void Start()
    {

        loader = gameObject.GetComponent<TransitionLoader>();

        if (loader == null)
        {
            loader = gameObject.AddComponent<TransitionLoader>();
        }

        // get upgrade array(s) from upgradeValues to change values accordingly
        runStart = true;
        ModifyUpgradeVals();
    }


    // Update is called once per frame
    void Update()
    {
        fuelSlider.value = testScript.currentFuel / maxFuel;
        runEnd = testScript.isFalling_End;
        if(runEnd)
        {
            runEnd = false;
            RunEnded();
        }
    }

    public void RunEnded()
    {
        
        atShop = true;
        runStart = true;
        //coinManager.addCoins(100);
        PauseGame();
        loader.goToShop();
        
        // show earnings made then transition to shop scene
    }

    public static void PauseGame()
    {
        // Debug.Log("paused game");
        Time.timeScale = 0f;
    }

    public void ModifyUpgradeVals()
    {
        ModifySingleUpgrade("launchers");
        ModifySingleUpgrade("solarPanels");
        ModifySingleUpgrade("weightRedistributions");
        ModifySingleUpgrade("fuelEfficiency");
        ModifySingleUpgrade("softwareUpdates");
        ModifySingleUpgrade("wealthExpediters");
    }

    public void ModifySingleUpgrade(string upgradeName)
    {
        var upgradeBoolArray = new bool[1];
        switch (upgradeName)
        {
            case "launchers":
                upgradeBoolArray = upgradeManager.getUpgradeArray(upgradeName);
                break;
            case "solarPanels":
                upgradeBoolArray = upgradeManager.getUpgradeArray(upgradeName);
                break;
            case "weightRedistributions":
                upgradeBoolArray = upgradeManager.getUpgradeArray(upgradeName);
                break;
            case "navigationControls":
                upgradeBoolArray = upgradeManager.getUpgradeArray(upgradeName);
                break;
            case "softwareUpdates":
                upgradeBoolArray = upgradeManager.getUpgradeArray(upgradeName);
                break;
            case "wealthExpediters":
                upgradeBoolArray = upgradeManager.getUpgradeArray(upgradeName);
                break;
            default:
                return;
        }

        PerformUpgrade(upgradeName, upgradeBoolArray);
    }

    public void PerformUpgrade(string upgradeNam, bool[] arr)
    {
        switch(upgradeNam)
        {
            case "launchers": // this is actually the thruster upgrade
                if (arr[0])
                {
                    upgradeThrusters1();
                }
                if (arr[1])
                {
                    upgradeThrusters2();
                }
                if (arr[2])
                {
                    upgradeThrusters3();
                }
                break;
            case "solarPanels":
                if (arr[0])
                {
                    upgradeSolarPanels1();
                }
                if (arr[1])
                {
                    upgradeSolarPanels2();
                }
                if (arr[2])
                {
                    upgradeSolarPanels3();
                }
                break;
            case "weightRedistributions":
                if (arr[0])
                {
                    upgradeWeightTransfer1();
                }
                if (arr[1])
                {
                    upgradeWeightTransfer2();
                }
                if (arr[2])
                {
                    upgradeWeightTransfer3();
                }
                break;
            case "fuelEfficiency": // this is actually the launcher upgrade
                if (arr[0])
                {
                    upgradeLaunchers1();
                }
                if (arr[1])
                {
                    upgradeLaunchers2();
                }
                if (arr[2])
                {
                    upgradeLaunchers3();
                }
                break;
            case "softwareUpdates": // this is actually the fuel upgrade
                if (arr[0])
                {
                    upgradeFuelEfficiency1();
                }
                if (arr[1])
                {
                    upgradeFuelEfficiency2();
                }
                if (arr[2])
                {
                    upgradeFuelEfficiency3();
                }
                break;
            case "wealthExpediters":
                if (arr[0])
                {
                    upgradeWealthExpediter1();
                }
                if (arr[1])
                {
                    upgradeWealthExpediter2();
                }
                if (arr[2])
                {
                    upgradeWealthExpediter3();
                }
                break;
            default:
                return;
        }
    }

    public void upgradeLaunchers1()
    {
        // increase the launch speed minimally
        launch_speed = 65f;
    }

    public void upgradeLaunchers2()
    {
        // increase the launch speed moderately
        launch_speed = 90f;
    }

    public void upgradeLaunchers3()
    {
        // increase the launch speed significantly 
        launch_speed = 125;
    }

    public void upgradeSolarPanels1()
    {
        // marginally increases the efficiency of fuel
        fuelBurnRate = 8f;
    }

    public void upgradeSolarPanels2()
    {
        // moderately increases the efficiency of fuel
        fuelBurnRate = 6f;
    }

    public void upgradeSolarPanels3()
    {
        // significantly increases the efficiency of fuel
        fuelBurnRate = 4.5f;
    }

    public void upgradeWeightTransfer1()
    {
        // minimally reduce speed loss/impact from collisions
        collisionReduction = .66f;
    }

    public void upgradeWeightTransfer2()
    {
        // moderately reduce speed loss/impact from collisions
        collisionReduction = .33f;
    }
    public void upgradeWeightTransfer3()
    {
        // significantly reduce speed loss/impact from collisions
        collisionReduction = .1f;
    }

    public void upgradeThrusters1()
    {
        // marginally increase boost speed
        boost_speed = 27.5f;
    }

    public void upgradeThrusters2()
    {
        // moderately increase boost speed
        boost_speed = 40f;
    }

    public void upgradeThrusters3()
    {
        // significantly increase boost speed
        boost_speed = 55f;
    }

    public void upgradeFuelEfficiency1()
    {
        // marginally increase fuel efficiency/capacity
        maxFuel = 125;
    }

    public void upgradeFuelEfficiency2()
    {
        // moderately increase fuel capacity
        maxFuel = 165;
    }

    public void upgradeFuelEfficiency3()
    {
        // significantly increase fuel capacity
        maxFuel = 230f;
    }

    public void upgradeWealthExpediter1()
    {
        // marginally increase coins gained
        coinDistanceMultiplier = 1.5f;
        coinValue = 50;
    }

    public void upgradeWealthExpediter2()
    {
        // moderately increase coins gained
        coinDistanceMultiplier = 2f;
        coinValue = 75;
    }

    public void upgradeWealthExpediter3()
    {
        // significantly increase koins gained
        coinDistanceMultiplier = 3f;
        coinValue = 100;
    }

}


