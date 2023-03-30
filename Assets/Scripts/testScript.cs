
using System;
using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable] public class testScript : MonoBehaviour
{
    private Transform pos;
    private Rigidbody2D body;
    private BoxCollider2D collid;
    // Vector3 position;
    // Quaternion rotation;

    [SerializeField] private AudioSource jumpSoundEffect;

    // private bool run_start = false;
    private bool isBoosting = false;
    private bool isGrounded = false;
    private bool isFalling_Boost = false;
    public static bool isFalling_End = false;
    public static float currentFuel;
    private float maxFuel;
    private float moveInput;
    private float fallingBoostThreshold;
    private float fallingRunEndThreshold;
    private float xStart;
    private float yStart;
    [SerializeField] private TMP_Text launch_text;

    GameManager gameManager;
    public void Awake()
    {
        // set necessary values
        pos = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
        collid = GetComponent<BoxCollider2D>();
        gameManager = FindObjectOfType<GameManager>();
        xStart = pos.position.x;
        yStart = pos.position.y;
        maxFuel = gameManager.maxFuel;
        currentFuel = maxFuel;
       // run_start = true;
        launch_text.enabled = false;
        launch_text.alpha = 0f;
        fallingBoostThreshold = -3f;
        fallingRunEndThreshold = -18.0f;

    }

    private void Update()
    {

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
            isFalling_Boost = false;
            isFalling_End = true;
            
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

        if(Input.GetKey(KeyCode.Space))
        {
            jumpSoundEffect.Play();
        }

    }

    private void FixedUpdate()
    {
       
            if (GameManager.runStart)
            {
                GameManager.runStart = false;
                launch_text.enabled = true;
                StartCoroutine(waitForKeyPress());
            }

            if (((isBoosting) && (currentFuel > 0)) && (!isFalling_Boost)) // when boosting
            {
                currentFuel -= gameManager.fuelBurnRate * Time.deltaTime; // decrease fuel by its burn rate, update the slider to show this
                body.AddForce(0.8f * gameManager.boost_speed * Vector2.up); // update velocity when boosting
                body.velocity = new Vector2(moveInput * gameManager.move_speed, body.velocity.y);
            }

            else if (((isFalling_Boost) && (isBoosting)) && (currentFuel > 0))
            {
                body.velocity = new Vector2(moveInput * gameManager.move_speed, gameManager.boost_speed*1.1f);
                isFalling_Boost = false;
            }

            else if (!isGrounded)
            {
                body.velocity = new Vector2(moveInput * gameManager.move_speed, body.velocity.y);
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
        body.velocity = new Vector2(body.velocity.x, gameManager.launch_speed);
        Debug.Log("completed the launch");

    }

}
