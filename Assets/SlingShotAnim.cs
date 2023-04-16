using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotAnim : MonoBehaviour
{


    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startSlingAnim()
    {
        animator.SetTrigger("Start_Slingshot");
    }
}
