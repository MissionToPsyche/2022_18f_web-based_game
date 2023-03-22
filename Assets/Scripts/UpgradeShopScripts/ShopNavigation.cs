using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopNavigation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchSceneToGame(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName: "MainGameScene");
    }

    public void switchSceneToGameJulian()
    {
        GameManager.runStart = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameSceneJulian");
    }

    public void switchSceneToMainMenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName: "MainMenuScene");
    }
}
