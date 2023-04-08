using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public Sprite[] budgetSpriteArray;
    public Sprite[] fuelSpriteArray;
    public Sprite[] solarSpriteArray;

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKey("space")){
            spriteRenderer.sprite = solarSpriteArray[2];
        }
        else{
            spriteRenderer.sprite = solarSpriteArray[0];
        }
    }

    //grab correct sprite method for budget
    public Sprite getBudgetSprite(bool[] budgetArray){
        if (budgetArray[0]){
            return budgetSpriteArray[0];
        }
        if (budgetArray[1]){
            return budgetSpriteArray[1];
        }
        if (budgetArray[2]){
            return budgetSpriteArray[2];
        }
        else{
            return null;
        }
    }

    //grab correct sprite method for fuel
    public Sprite getFuelSprite(bool[] fuelArray){
        if (fuelArray[0]){
            return fuelSpriteArray[0];
        }
        if (fuelArray[1]){
            return fuelSpriteArray[1];
        }
        if (fuelArray[2]){
            return fuelSpriteArray[2];
        }
        else{
            return null;
        }
    }

    //grab correct sprite method for solar
    public Sprite getSolarSprite(bool[] solArray){
        if (solArray[0]){
            return solarSpriteArray[0];
        }
        if (solArray[1]){
            return solarSpriteArray[1];
        }
        if (solArray[2]){
            return solarSpriteArray[2];
        }
        else{
            return null;
        }
    }
}
