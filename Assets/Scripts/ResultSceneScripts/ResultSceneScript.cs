using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSceneScript : MonoBehaviour
{

    [SerializeField] private TMPro.TextMeshProUGUI distanceText;
    [SerializeField] private TMPro.TextMeshProUGUI coinText;
    [SerializeField] private TMPro.TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Sheesh");
        distanceText.text = "Distance Traveled: " + DataTransferStatic.getDistanceTraveled(); 
        coinText.text = "Coins Collected: " + DataTransferStatic.getCoinsCollected();
        //timeText.text = "Flight Duration: " + DataTransferStatic.getFlightDuration();
    }

    public void transitionToShop(){
        Debug.Log("transitioning to shop");
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName: "ShopScene");
    }
}
