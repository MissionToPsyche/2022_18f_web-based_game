using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteController : MonoBehaviour
{
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space")){
            spriteRenderer.sprite = spriteArray[1];
        }
        else{
            spriteRenderer.sprite = spriteArray[0];
        }
    }
}
