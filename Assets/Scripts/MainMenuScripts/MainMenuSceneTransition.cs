using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneTransition : MonoBehaviour
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
}
