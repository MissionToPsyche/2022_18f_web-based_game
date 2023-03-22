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
        coinManager.addCoins(100);
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
            case "launchers":
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
            case "fuelEfficiency":
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
            case "softwareUpdates":
                if (arr[0])
                {
                    upgradeSoftwareUpdate1();
                }
                if (arr[1])
                {
                    upgradeSoftwareUpdate2();
                }
                if (arr[2])
                {
                    upgradeSoftwareUpdate3();
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
        Debug.Log(launch_speed);


    }

    public void upgradeLaunchers2()
    {
        // increase the launch speed moderately
        launch_speed = 90f;
        Debug.Log(launch_speed);


        // deduct the price of upgrade from current coins

    }

    public void upgradeLaunchers3()
    {
        // increase the launch speed significantly 
        launch_speed = 125;
        Debug.Log(launch_speed);


        // deduct the price of upgrade from current coins
    }

    public void upgradeSolarPanels1()
    {
        // marginally increases the power of thrusters/boost
        boost_speed = 27.5f;

        // deduct the price of upgrade from current coins
    }

    public void upgradeSolarPanels2()
    {
        // moderately increases the power of thrusters/boost
        boost_speed = 40;


        // deduct the price of upgrade from current coins
    }

    public void upgradeSolarPanels3()
    {
        // significantly increases the power of thrusters/boost
        boost_speed = 55f;


        // deduct the price of upgrade from current coins
    }

    public void upgradeWeightTransfer1()
    {
        // minimally reduce speed loss/impact from collisions


        // deduct the price of upgrade from current coins
    }

    public void upgradeWeightTransfer2()
    {
        // moderately reduce speed loss/impact from collisions


        // deduct the price of upgrade from current coins
    }
    public void upgradeWeightTransfer3()
    {
        // significantly reduce speed loss/impact from collisions


        // deduct the price of upgrade from current coins
    }

    public void upgradeSoftwareUpdate1()
    {
        // marginally increase horizontal move speed
        move_speed = 25f;

        // deduct the price of upgrade from current coins
    }

    public void upgradeSoftwareUpdate2()
    {
        // moderately increase horizontal move speed
        move_speed = 30f;
        Debug.Log(move_speed);


        // deduct the price of upgrade from current coins
    }

    public void upgradeSoftwareUpdate3()
    {
        // significantly increase horizontal move speed
        move_speed = 37.5f;


        // deduct the price of upgrade from current coins
    }

    public void upgradeFuelEfficiency1()
    {
        // marginally increase fuel efficiency/capacity
        fuelBurnRate = 8f;
        maxFuel = 125;

        // deduct the price of upgrade from current coins
    }

    public void upgradeFuelEfficiency2()
    {
        // moderately increase fuel efficiency/capacity
        fuelBurnRate = 6f;
        maxFuel = 165;


        // deduct the price of upgrade from current coins
    }

    public void upgradeFuelEfficiency3()
    {
        // significantly increase fuel efficiency/capacity
        fuelBurnRate = 4.5f;
        maxFuel = 230f;


        // deduct the price of upgrade from current coins
    }

    public void upgradeWealthExpediter1()
    {
        // marginally increase coins gained


        // deduct the price of upgrade from current coins
    }

    public void upgradeWealthExpediter2()
    {
        // moderately increase coins gained


        // deduct the price of upgrade from current coins
    }

    public void upgradeWealthExpediter3()
    {
        // significantly increase koins gained


        // deduct the price of upgrade from current coins
    }

}


