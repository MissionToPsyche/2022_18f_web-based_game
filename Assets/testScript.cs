
using System;
using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class testScript : MonoBehaviour
{
    private Transform pos;
    private Rigidbody2D body;
    private BoxCollider2D collid;
    [SerializeField] private float boost_speed = 20f;
    [SerializeField] private float move_speed = 15f;
    [SerializeField] private float launch_speed = 50f;
    [SerializeField] private float maxFuel = 100f;
    [SerializeField] private float fuelBurnRate = 10f;


    private bool hasLaunched = true;
    private bool runStart = false;
    private bool isBoosting = false;
    private bool isGrounded = false;
    private bool isFalling_Boost = false;
    private bool isFalling_End = false;
    private float currentFuel;
    private float moveInput;
    private float fallingBoostThreshold;
    private float fallingRunEndThreshold;

    [SerializeField] private Slider fuelSlider;
    [SerializeField] private TMP_Text launch_text;
    public void Start()
    {
        pos = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
        collid = GetComponent<BoxCollider2D>();
        currentFuel = maxFuel;
        runStart = true;
        launch_text.enabled = false;
        launch_text.alpha = 0f;
        fallingBoostThreshold = -3f;
        fallingRunEndThreshold = -24.0f;
    }

    private void Update()
    {
        fuelSlider.value = currentFuel / maxFuel;
        if (pos.position.y > 170)
        {
            moveInput = Input.GetAxis("Horizontal");
        }

        if (pos.position.y < 169)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if(body.velocity.y < fallingBoostThreshold)
        {
            isFalling_Boost = true;
            Debug.Log("triggered falling_boost");

        }
        else
        {
            isFalling_Boost = false;
        }

        if(body.velocity.y < fallingRunEndThreshold)
        {
            Debug.Log("triggered falling_end");
            isFalling_End = true;
            isFalling_Boost = false;
            RunEnded();
        }

        else
        {
            isFalling_End = false;
          //  isFalling_Boost = false;
        }

        if (!isGrounded)
        {
            isBoosting = Input.GetKey(KeyCode.Space);
        }

    }

    private void FixedUpdate()
    {
        if (runStart)
        {
            runStart = false;
            launch_text.enabled = true;
            StartCoroutine(waitForKeyPress());
        }

        if (((isBoosting) && (currentFuel > 0)) && (!isFalling_Boost)) // when boosting
        {
            currentFuel -= fuelBurnRate * Time.deltaTime; // decrease fuel by its burn rate, update the slider to show this
            body.AddForce(Vector2.up * boost_speed*0.8f); // update velocity when boosting
            body.velocity = new Vector2(moveInput * move_speed, body.velocity.y);
        }

        else if (((isFalling_Boost) && (isBoosting)) && (currentFuel > 0))
        {
            Debug.Log("got here dammit");
            body.velocity = new Vector2(moveInput * move_speed, boost_speed);
        }

        else if(!isGrounded)
        {
            body.velocity = new Vector2(moveInput * move_speed, body.velocity.y);
        }

    }

   IEnumerator waitForKeyPress()
    {
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
   
        Launch();
        launch_text.enabled = false;
        yield return new WaitForSeconds(0);
    }

    public void Launch() // initial launch, burst of upward momentum
    {
        Debug.Log("got to launch");
        body.velocity = new Vector2(body.velocity.x, launch_speed);
        Debug.Log("completed the launch");

    }

    public void RunEnded()
    {
        PauseGame();
        // show earnings made then transition to shop scene
        // SceneManager.LoadScene("ShopScene");
    }

    public void PauseGame()
    {
       // Debug.Log("paused game");
        Time.timeScale = 0f;
    }
}


/*
 * 
 * if (pos.position.y > 170)
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * move_speed, body.velocity.y);
        }
        if (pos.position.y < 170)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                body.velocity = new Vector2(body.velocity.x, vertical_speed);
            }
        } 
 * 
 * 
 */
