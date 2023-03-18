using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.WSA;

public class GameManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    public static float boost_speed = 20f;
    public static float move_speed = 15f;
    public static float launch_speed = 50f;
    public static float maxFuel = 100f;
    public static float fuelBurnRate = 10f;

    public static bool runStart = true;
    public static bool atShop = false;


    [SerializeField] private Slider fuelSlider;

    // Update is called once per frame
    void Update()
    {
        fuelSlider.value = testScript.currentFuel / maxFuel;
    }

    public static void RunEnded()
    {
        PauseGame();
        runStart = true;
        atShop = true;
        // show earnings made then transition to shop scene
        SceneManager.LoadScene("ShopScene");
    }

    public static void PauseGame()
    {
        // Debug.Log("paused game");
        Time.timeScale = 0f;
    }

}
