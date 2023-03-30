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
    void Start()
    {
        psycheCraft = GameObject.Find("/Psyche/PsycheCraft");
        InvokeRepeating("CoinGenerator", 2.0f, 2f);
        InvokeRepeating("AstroidGenerator", 2.0f, 1.5f);
        //AstroidGenerator();
        //CoinGenerator();
    }
    
    void Update()
    {
        //AstroidGenerator();
        //CoinGenerator();
    }

    private GameObject AstroidGenerator(){
        GameObject go = new GameObject();
        go.name = "Astroid";
        go.AddComponent<SpriteRenderer>();
        go.AddComponent<BoxCollider2D>();
        go.GetComponent<BoxCollider2D>().size = new Vector3(25f, 19f, 1f);
        //go.GetComponent<BoxCollider2D>().size = new Vector3(1f, 1f, 1f);
        go.GetComponent<BoxCollider2D>().isTrigger = true;

        go.GetComponent<SpriteRenderer>().sprite = astroid;
        Vector3 tempPos = psycheCraft.GetComponent<Transform>().position;

        tempPos += new Vector3(Random.Range(-20f,20f), 50, 0);
        //tempPos += new Vector3(-25f, 1, 0);
        go.GetComponent<Transform>().position = tempPos;
        go.GetComponent<Transform>().localScale = new Vector3(.1f,.1f,.1f);
        Destroy(go, 30f);
        return go;
    }

    private GameObject CoinGenerator(){
        GameObject go = new GameObject();
        go.name = "Coin";
        go.AddComponent<SpriteRenderer>();
        go.AddComponent<BoxCollider2D>();
        go.GetComponent<BoxCollider2D>().isTrigger = true;
        go.GetComponent<BoxCollider2D>().size = new Vector3(.65f, .65f, 1f);
        //go.GetComponent<BoxCollider2D>().size = new Vector3(1f, 1f, 1f);
        go.GetComponent<SpriteRenderer>().sprite = coin;
        Vector3 tempPos = psycheCraft.GetComponent<Transform>().position;

        tempPos += new Vector3(Random.Range(-20f,20f), 50, 0);
        //tempPos += new Vector3(-25f, 1, 0);
        go.GetComponent<Transform>().position = tempPos;
        go.GetComponent<Transform>().localScale = new Vector3(3f,3f,3f);
        Destroy(go, 15f);
        return go;
    }

/*  doesnt work
    private void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("Item Gen:" + collision.gameObject.name);
        Destroy(this.gameObject);
    }*/

}
