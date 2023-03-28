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
    }
    
    void Update()
    {
        AstroidGenerator();
        CoinGenerator();
    }

    private GameObject AstroidGenerator(){
        GameObject go = new GameObject();
        go.AddComponent<SpriteRenderer>();
        go.GetComponent<SpriteRenderer>().sprite = astroid;
        Vector3 tempPos = psycheCraft.GetComponent<Transform>().position;

        tempPos += new Vector3(Random.Range(-20f,20f), 25, 0);
        //tempPos += new Vector3(-25f, 1, 0);
        go.GetComponent<Transform>().position = tempPos;
        go.GetComponent<Transform>().localScale = new Vector3(.05f,.05f,.05f);
        return go;
    }

    private GameObject CoinGenerator(){
        GameObject go = new GameObject();
        go.AddComponent<SpriteRenderer>();
        go.GetComponent<SpriteRenderer>().sprite = coin;
        Vector3 tempPos = psycheCraft.GetComponent<Transform>().position;

        tempPos += new Vector3(Random.Range(-20f,20f), 25, 0);
        //tempPos += new Vector3(-25f, 1, 0);
        go.GetComponent<Transform>().position = tempPos;
        go.GetComponent<Transform>().localScale = new Vector3(2f,2f,2f);
        return go;
    }
}
