using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgScroller : MonoBehaviour
{
    public float scrollSpeed = -5;

    // Update is called once per frame
    void Update()
    {
        float speedAdjusted = scrollSpeed;
        if(Input.GetKey("space")){
            speedAdjusted = scrollSpeed * 1.75f;
        }else{
            speedAdjusted = scrollSpeed;
        }

        float fuel = FindObjectOfType<psycheResourceController>().getFuel();
        if(fuel <= 0){
            speedAdjusted = -0.5f;
        }

        transform.position += new Vector3(speedAdjusted * Time.deltaTime, 0);
        if(transform.position.x < -20.5){
            transform.position = new Vector3(20.5f, transform.position.y, 5);
        }
    }
}
