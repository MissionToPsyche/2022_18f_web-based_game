using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class ItemGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject psycheCraft;
    private Transform transform;
    private Vector3 pos;
    //private static Random rnd = new System.Random();

    [SerializeField] private Sprite astroid;
    [SerializeField] private Sprite coin;
    [SerializeField] private Sprite cloud;
    [SerializeField] private Sprite fuel;
    [SerializeField] private Sprite bird;

    private float coinStart = 0f;
    private float coinEnd = 10000000f;

    private float astroidStart = 0f;
    private float astroidEnd = 10000000f;

    private float cloudStart = 0f;
    private float cloudEnd = 5000f;

    private float fuelStart = 0f;
    private float fuelEnd = 10000000f;

    private float birdStart = 0f;
    private float birdEnd = 5000f;

    void Start()
    {
        psycheCraft = GameObject.Find("/Psyche/PsycheCraft");
        InvokeRepeating("CoinGenerator", 2.0f, 2f);
        InvokeRepeating("AstroidGenerator", 2.0f, 1.5f);
        InvokeRepeating("CloudGenerator", 2.0f, 1f);
        InvokeRepeating("FuelGenerator", 2.0f, 5f);
        InvokeRepeating("BirdGenerator", 2.0f, 5f);

        for(int i = 0; i < 5; i++){
            CloudGenerator();
            CoinGenerator();
        }
        //AstroidGenerator();
        //CoinGenerator();
    }
    
    void Update()
    {
        //AstroidGenerator();
        //CoinGenerator();
    }

    private void AstroidGenerator(){
        Vector3 tempPos = psycheCraft.GetComponent<Transform>().position;
        float y = tempPos.y;
        if(!(astroidStart <= y && y <= astroidEnd)){
            return;
        }
        GameObject go = new GameObject();
        go.name = "Astroid";
        go.AddComponent<SpriteRenderer>();
        go.AddComponent<BoxCollider2D>();
        go.GetComponent<BoxCollider2D>().size = new Vector3(25f, 19f, 1f);
        //go.GetComponent<BoxCollider2D>().size = new Vector3(1f, 1f, 1f);
        go.GetComponent<BoxCollider2D>().isTrigger = true;

        go.GetComponent<SpriteRenderer>().sprite = astroid;

        tempPos += new Vector3(Random.Range(-20f,20f), Random.Range(50f,100f), 0);
        //tempPos += new Vector3(-25f, 1, 0);
        go.GetComponent<Transform>().position = tempPos;
        go.GetComponent<Transform>().localScale = new Vector3(.1f,.1f,.1f);
        Destroy(go, 30f);
        return;
    }

    private void CoinGenerator(){
        Vector3 tempPos = psycheCraft.GetComponent<Transform>().position;
        float y = tempPos.y;
        if(!(coinStart <= y && y <= coinEnd)){
            return;
        }
        GameObject go = new GameObject();
        go.name = "Coin";
        go.AddComponent<SpriteRenderer>();
        go.AddComponent<BoxCollider2D>();
        go.GetComponent<BoxCollider2D>().isTrigger = true;
        go.GetComponent<BoxCollider2D>().size = new Vector3(.65f, .65f, 1f);
        //go.GetComponent<BoxCollider2D>().size = new Vector3(1f, 1f, 1f);
        go.GetComponent<SpriteRenderer>().sprite = coin;

        tempPos += new Vector3(Random.Range(-20f,20f), Random.Range(50f,100f), 0);
        //tempPos += new Vector3(-25f, 1, 0);
        go.GetComponent<Transform>().position = tempPos;
        go.GetComponent<Transform>().localScale = new Vector3(3f,3f,3f);
        Destroy(go, 15f);
        return;
    }

    private void CloudGenerator(){
        Vector3 tempPos = psycheCraft.GetComponent<Transform>().position;
        float y = tempPos.y;
        if(!(cloudStart <= y && y <= cloudEnd)){
            return;
        }
        GameObject go = new GameObject();
        go.name = "Cloud";
        go.AddComponent<SpriteRenderer>();
        go.GetComponent<SpriteRenderer>().sprite = cloud;

        tempPos += new Vector3(Random.Range(-20f,20f), Random.Range(50f,100f), 0);
        go.GetComponent<Transform>().position = tempPos;
        //go.GetComponent<Transform>().localScale = new Vector3(.1f,.1f,.1f);
        Destroy(go, 30f);
        return;
    }
    private void FuelGenerator(){
        Vector3 tempPos = psycheCraft.GetComponent<Transform>().position;
        float y = tempPos.y;
        if(!(fuelStart <= y && y <= fuelEnd)){
            return;
        }
        GameObject go = new GameObject();
        go.name = "Fuel";
        go.AddComponent<SpriteRenderer>();
        go.AddComponent<BoxCollider2D>();
        go.GetComponent<BoxCollider2D>().isTrigger = true;
        go.GetComponent<BoxCollider2D>().size = new Vector3(1.695577f, 2.058449f, 1f);
        go.GetComponent<SpriteRenderer>().sprite = fuel;

        tempPos += new Vector3(Random.Range(-20f,20f), Random.Range(50f,100f), 0);
        go.GetComponent<Transform>().position = tempPos;
        go.GetComponent<Transform>().localScale = new Vector3(.8f,.8f,1f);
        Destroy(go, 15f);
        return;
    }

    private void BirdGenerator(){
        Vector3 tempPos = psycheCraft.GetComponent<Transform>().position;
        float y = tempPos.y;
        if(!(birdStart <= y && y <= birdEnd)){
            return;
        }
        GameObject go = new GameObject();
        go.name = "Bird";
        go.AddComponent<SpriteRenderer>();
        go.AddComponent<BoxCollider2D>();
        go.GetComponent<BoxCollider2D>().size = new Vector3(15.85146f, 11.75446f, 1f);
        //go.GetComponent<BoxCollider2D>().size = new Vector3(1f, 1f, 1f);
        go.GetComponent<BoxCollider2D>().isTrigger = true;

        go.GetComponent<SpriteRenderer>().sprite = bird;

        tempPos += new Vector3(Random.Range(-20f,20f), Random.Range(50f,100f), 0);
        //tempPos += new Vector3(-25f, 1, 0);
        go.GetComponent<Transform>().position = tempPos;
        go.GetComponent<Transform>().localScale = new Vector3(.15f,.15f,.15f);
        Destroy(go, 30f);
        return;
    }
}
