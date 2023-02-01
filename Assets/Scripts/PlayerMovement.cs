using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float adjustedSpeed;
        if(Input.GetKey("space")){
            adjustedSpeed = speed * 1.75f;
        }else{
            adjustedSpeed = speed;
        }


        float fuel = FindObjectOfType<psycheResourceController>().getFuel();
        if(fuel <= 0){
            adjustedSpeed = 1f;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 pos = transform.position;

        pos.x += h * adjustedSpeed * Time.deltaTime;
        pos.y += v * adjustedSpeed * Time.deltaTime;

        transform.position = pos;
    }
}
