using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSceneScript : MonoBehaviour
{

    [SerializeField] private TMPro.TextMeshProUGUI distanceText;
    [SerializeField] private TMPro.TextMeshProUGUI coinText;
    [SerializeField] private TMPro.TextMeshProUGUI timeText;
    [SerializeField] private TMPro.TextMeshProUGUI totalCoinText;

    private CoinManager coinManager = new CoinManager();
    // Start is called before the first frame update
    void Start()
    {

        int totalCoinsEarned = computeCoinsEarned();

        Debug.Log("Sheesh");
        distanceText.text = "Distance Traveled: " + DataTransferStatic.getDistanceTraveled().ToString("0.00"); 
        coinText.text = "Coins Collected: " + DataTransferStatic.getCoinsCollected();
        timeText.text = "Flight Duration: " + DataTransferStatic.getFlightDuration().ToString("0.00");
        totalCoinText.text = "Total Coins Earned: " + totalCoinsEarned;
        coinManager.addCoins(totalCoinsEarned);  

    }

    public void transitionToShop(){
        Debug.Log("transitioning to shop");
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName: "UpdatedShopScene");
    }

    private int computeCoinsEarned(){   
        float result = DataTransferStatic.getCoinsCollected();
        float distance = DataTransferStatic.getDistanceTraveled();
        result = result +  distance * DataTransferStatic.getCoinDistanceMultiplier() * .01f;
        return (int) result;

    }
}
