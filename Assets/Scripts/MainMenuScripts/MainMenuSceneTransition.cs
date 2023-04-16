using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneTransition : MonoBehaviour
{
    public void switchSceneToGame(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName: "GameSceneJulian");
    }

    public void switchSceneToShop(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName: "ShopScene");
    }

    public void switchSceneToUpdatedMainMenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName: "UpdatedMainMenu");
    }
}
