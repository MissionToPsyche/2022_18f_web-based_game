using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionLoader : MonoBehaviour
{

    public Animator transition;


    // Update is called once per frame
    private void Awake()
    {
        transition.updateMode = AnimatorUpdateMode.UnscaledTime;
    }


    public void goToShop()
    {
        StartCoroutine(goToShopScene());
    }

    public IEnumerator goToShopScene()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(1);

        SceneManager.LoadScene("ResultScene");
    }
}
