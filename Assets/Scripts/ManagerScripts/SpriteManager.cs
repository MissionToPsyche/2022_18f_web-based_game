using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public Sprite craft;

    public Sprite[] budgetSpriteArray;
    public Sprite[] fuelSpriteArray;
    public Sprite[] solarSpriteArray;
    public Sprite[] solarNoBoostArray;

    public Sprite finalShip = null;
    public Sprite finalBoostedShip = null;

    public SpriteRenderer spriteRenderer = null;

    // Start is called before the first frame update
    void Start()
    {
        MergeBoostedSprites();
        MergeSprites();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKey("space")){
            spriteRenderer.sprite = finalBoostedShip;
        }
        else{
            spriteRenderer.sprite = finalShip;
        }
    }

    public void MergeBoostedSprites(){

        Resources.UnloadUnusedAssets();

        Sprite mergedShip = null;

        Sprite[] spritesToMerge = {solarSpriteArray[2],craft};
        Sprite[] spritesToShip = {craft, budgetSpriteArray[2], fuelSpriteArray[2]};

        var newCraft = new Texture2D(37,103);

        for(int x = 0; x < newCraft.width; x++){
            for(int y = 0; y < newCraft.height; y++){
                newCraft.SetPixel(x,y, new Color(1,1,1,0));
            }
        }

        for(int i = 0; i < spritesToShip.Length; i++){
            for(int x = 0; x < spritesToShip[i].texture.width; x++){
                for(int y = 0; y < spritesToShip[i].texture.height; y++){
                    var color = spritesToShip[i].texture.GetPixel(x, y).a == 0 ?
                                    newCraft.GetPixel(x,y) :
                                    spritesToShip[i].texture.GetPixel(x,y);
                    newCraft.SetPixel(x,y, color);
                }
            }
        }
        newCraft.Apply();
        mergedShip = Sprite.Create(newCraft, new Rect(0, 0, newCraft.width, newCraft.height), new Vector2(0.5f, 0.5f));

        spritesToMerge[1] = mergedShip;

        int solarWidth = (int)solarSpriteArray[2].rect.width;
        int craftWidth = (int)newCraft.width;

        var newTexture = new Texture2D(solarWidth+craftWidth, 103);

        for(int x = 0; x < newTexture.width; x++){
            for(int y = 0; y < newTexture.height; y++){
                newTexture.SetPixel(x,y, new Color(1,1,1,0));
            }
        }

        int xOffset = 0;

        for(int i = 0; i < spritesToMerge.Length; i++){
            
            for(int x = 0; x < spritesToMerge[i].texture.width; x++){
                for(int y = 0; y < spritesToMerge[i].texture.height; y++){
                    Color color = spritesToMerge[i].texture.GetPixel(x,y);
                    newTexture.SetPixel(x + xOffset, y, color);
                }
                
                if(x == spritesToMerge[i].texture.width - 1){
                    xOffset += x; 
                }
            }
        }

        newTexture.Apply();

        finalBoostedShip = Sprite.Create(newTexture, new Rect(0, 0, newTexture.width, newTexture.height), new Vector2(0.5f, 0.5f));
        finalBoostedShip.name = "finalBMergedShip";
        
        spriteRenderer.sprite = finalBoostedShip;
    }

    public void MergeSprites(){

        Resources.UnloadUnusedAssets();

        Sprite mergedShip = null;

        Sprite[] spritesToMerge = {solarNoBoostArray[2],craft};

        Sprite[] spritesToShip = {craft, budgetSpriteArray[2], fuelSpriteArray[2]};

        var newCraft = new Texture2D(37,103);

        for(int x = 0; x < newCraft.width; x++){
            for(int y = 0; y < newCraft.height; y++){
                newCraft.SetPixel(x,y, new Color(1,1,1,0));
            }
        }

        for(int i = 0; i < spritesToShip.Length; i++){
            for(int x = 0; x < spritesToShip[i].texture.width; x++){
                for(int y = 0; y < spritesToShip[i].texture.height; y++){
                    var color = spritesToShip[i].texture.GetPixel(x, y).a == 0 ?
                                    newCraft.GetPixel(x,y) :
                                    spritesToShip[i].texture.GetPixel(x,y);
                    newCraft.SetPixel(x,y, color);
                }
            }
        }
        newCraft.Apply();
        mergedShip = Sprite.Create(newCraft, new Rect(0, 0, newCraft.width, newCraft.height), new Vector2(0.5f, 0.5f));

        spritesToMerge[1] = mergedShip;

        int solarWidth = (int)solarSpriteArray[2].rect.width;
        int craftWidth = (int)newCraft.width;

        var newTexture = new Texture2D(solarWidth+craftWidth, 103);
        
        for(int x = 0; x < newTexture.width; x++){
            for(int y = 0; y < newTexture.height; y++){
                newTexture.SetPixel(x,y, new Color(1,1,1,0));
            }
        }

        int xOffset = 0;

        for(int i = 0; i < spritesToMerge.Length; i++){
            for(int x = 0; x < spritesToMerge[i].texture.width; x++){
                for(int y = 0; y < spritesToMerge[i].texture.height; y++){
                    Color color = spritesToMerge[i].texture.GetPixel(x,y);
                    newTexture.SetPixel(x + xOffset, y, color);
                }
                
                if(x == spritesToMerge[i].texture.width - 1){
                    xOffset += x; 
                }
            }
        }

        newTexture.Apply();

        finalShip = Sprite.Create(newTexture, new Rect(0, 0, newTexture.width, newTexture.height), new Vector2(0.5f, 0.5f));
        finalShip.name = "finalMergedShip";
        
        spriteRenderer.sprite = finalShip;

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
