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

    private bool isJumpSoundPlaying = false;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource leftmoveeffect;
    [SerializeField] private AudioSource coinEffect;
    // [SerializeField] private AudioSource boomEffect;

    [SerializeField] private TMPro.TextMeshProUGUI distanceText;
    [SerializeField] private TMPro.TextMeshProUGUI speedText;
    [SerializeField] private TMPro.TextMeshProUGUI coinText;

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

    private int coinsCollected;
    private int coinsValue;

    private float distanceTraveled;
    private int obstaclesCrashedCount;
    private float flightDuration;
    private float coinDistMult;

    GameManager gameManager;
    public Animator slingshotAnim;
    public void Awake()
    {
        // DataTransferStatic is a static class for transfering data from game scene to result scene
        DataTransferStatic.resetData();

        // set necessary values
        pos = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
        collid = GetComponent<BoxCollider2D>();
        gameManager = FindObjectOfType<GameManager>();

        maxFuel = gameManager.maxFuel;
        currentFuel = maxFuel;
       // run_start = true;
        launch_text.enabled = false;
        launch_text.alpha = 0f;
        fallingBoostThreshold = -4.0f;
        fallingRunEndThreshold = -30.0f;

        distanceTraveled = 0;
        obstaclesCrashedCount = 0;
        flightDuration = 0f;

        coinsCollected = 0;
        coinsValue = gameManager.coinValue;
        coinDistMult = gameManager.coinDistanceMultiplier;
    }

    private void Update()
    {
        distanceText.text = "Altitude: " + body.position.y.ToString("0.00");
        speedText.text = "Speed: " + body.velocity.y.ToString("0.00");
        coinText.text = "Coins Collected: " + coinsCollected;

        DataTransferStatic.setDistanceTraveled(distanceTraveled);
        DataTransferStatic.setCoinsCollected(coinsCollected);
        DataTransferStatic.setFlightDuration(flightDuration);
        DataTransferStatic.setCoinDistanceMultiplier(coinDistMult);
        //DataTransferStatic.setFlightDuration()

        if(body.position.y > distanceTraveled){
            distanceTraveled = body.position.y;
        }

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
            flightDuration += Time.deltaTime;
            isGrounded = false;
        }

        if(body.velocity.y < fallingBoostThreshold)
        {
            isFalling_Boost = true;
            //Debug.Log("triggered falling_boost");

        }
        else
        {
            isFalling_Boost = false;
        }

        if(body.velocity.y < fallingRunEndThreshold)
        {
            //Debug.Log("triggered falling_end");
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

        if(Input.GetKeyDown(KeyCode.Space) && !isJumpSoundPlaying)
        {
            jumpSoundEffect.Play();
            isJumpSoundPlaying = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!jumpSoundEffect.isPlaying)
            {
                jumpSoundEffect.Play();
            }
            else
            {
                leftmoveeffect.Stop();
            }      
        }

    }

    private void FixedUpdate()
    {
       
            if (GameManager.runStart)
            {
                GameManager.runStart = false;
                launch_text.enabled = true;
                StartCoroutine(waitForKeyPress());
                // might need to launch here instead
            }

            if (((isBoosting) && (currentFuel > 0)) && (!isFalling_Boost)) // when boosting
            {
                currentFuel -= gameManager.fuelBurnRate * Time.fixedDeltaTime; // decrease fuel by its burn rate, update the slider to show this
               // body.AddForce(Vector2.up * 0.8f * gameManager.boost_speed); // update velocity when boosting
                body.velocity = new Vector2(moveInput * gameManager.move_speed, body.velocity.y + (gameManager.boost_speed * Time.fixedDeltaTime));
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

            if (!isGrounded)
            {
                body.velocity = new Vector2(moveInput * gameManager.move_speed, body.velocity.y);
                if (moveInput != 0) // Checking whether the rocket is moving right/left
                {
                    // if (!leftmoveeffect.isPlaying)
                    // {
                    //    leftmoveeffect.Play();
                    // }
                }
                else
                {
                    // if (leftmoveeffect.isPlaying)
                    // {
                    //     leftmoveeffect.Stop();
                    // }
                }
            }
    }

   IEnumerator waitForKeyPress()
    {
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        slingshotAnim.SetTrigger("Start_Slingshot");
        yield return new WaitForSeconds(0.3f);

        Launch();
        launch_text.enabled = false;
        yield return new WaitForSeconds(0);
    }

    public void Launch() // initial launch, burst of upward momentum
    {
        //Debug.Log("got to launch");
        body.velocity = new Vector2(body.velocity.x, gameManager.launch_speed);
        //Debug.Log("completed the launch");

    }

    private void OnTriggerEnter2D(Collider2D collision){
        string name = collision.gameObject.name;
        Debug.Log(collision.gameObject.name);
        if(name == "Ground"){
            // ground collision
        }
        else if(name == "Coin"){
            coinsValue = gameManager.coinValue;
            coinEffect.Play();
            Destroy(collision.gameObject, .02f);
            coinsCollected += coinsValue;
        }
        else if(name == "Astroid"){
            float speedReductionPercent = gameManager.collisionReduction;
            float astroidPenalty = .50f;
            // boomEffect.Play();
            Destroy(collision.gameObject, .02f);
            obstaclesCrashedCount += 1;
            //body.AddForce(15f * gameManager.boost_speed * Vector2.down); 
            body.velocity = new Vector2(moveInput * gameManager.move_speed, body.velocity.y - (body.velocity.y * speedReductionPercent * astroidPenalty));
        }
        else if(name == "Fuel"){
            //coinEffect.Play();
            Destroy(collision.gameObject, .02f);
            currentFuel += (maxFuel*.2f);
        }
        else if(name == "Bird"){
            float speedReductionPercent = gameManager.collisionReduction;
            float birdPenalty = .25f;
            //coinEffect.Play();
            Destroy(collision.gameObject, .02f);
            body.velocity = new Vector2(moveInput * gameManager.move_speed, body.velocity.y - (body.velocity.y * speedReductionPercent * birdPenalty));
        }
    }


    /*
    private void OnTriggerExit2D(Collider2D collision){
        Debug.Log(collision.gameObject.name);
        //Destroy(collision.gameObject);
    }
    */

}
