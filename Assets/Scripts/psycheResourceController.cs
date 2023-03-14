using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class psycheResourceController : MonoBehaviour
{
    public float fuel = 50f;
    public float startingFuel;
    public float startingFuelLossSpeed = 2f;
    public float FuelLossSpeed = 2f;
    public float startingVelocity = 50f;
    public float velocity = 50f;
    //public float velocityLoss = 0.001f;
    public float velocityLoss = 0;
    public float distance = 0f;

    public float waitTime = 1.5f;
    public float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        startingFuel = fuel;
    }

    // Update is called once per frame
    void Update()
    {
        if(fuel <= 0){
            timer += Time.deltaTime;
            if(timer > waitTime){
                changeScene();
            }
            return;
        }

        velocity = startingVelocity;
        FuelLossSpeed = startingFuelLossSpeed;

        if(Input.GetKey("space")){
            velocity = startingVelocity * 3f;
            FuelLossSpeed = startingFuelLossSpeed * 2f;
        }

        distance = distance + velocity * Time.deltaTime;
        fuel = fuel - FuelLossSpeed * Time.deltaTime;        
    }

    public float getDistance(){
        return distance;
    }

    public float getFuelPercentage(){
        return fuel/startingFuel;
    }

    public float getFuel(){
        return fuel;
    }

    public void changeScene(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName: "MainMenuScene");
    }
}
