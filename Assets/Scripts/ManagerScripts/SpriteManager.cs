using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public Sprite craft;

    //array that hass all the sprite upgrades 
    public Sprite[] budgetSpriteArray;
    public Sprite[] fuelSpriteArray;
    public Sprite[] solarSpriteArray;
    public Sprite[] solarNoBoostArray;

    //non-boosted sprite
    public Sprite finalShip = null;
    //boosted sprite
    public Sprite finalBoostedShip = null;

    public SpriteRenderer spriteRenderer = null;

    private UpgradeManager upManage = new UpgradeManager();

    private int solarIndex = 0;
    private int budgetindex = 0;
    private int fuelIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        modifyUpgradeVisuals();
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

    public void MergeBoostedSprites() {

        Resources.UnloadUnusedAssets();

        //creates Sprite variable for the ship texture with all sprites merged together
        Sprite mergedShip = null;

        //array to merge both the solar texture and the merged craft texture
        
        Sprite[] spritesToMerge = { solarSpriteArray[solarIndex], null };
        
        //array to merge the craft, budget upgrade sprite, and fuel sprite all ontop of each other
        Sprite[] spritesToShip = {craft, budgetSpriteArray[budgetindex], fuelSpriteArray[fuelIndex]};

        //create new Texture for merged sprites that will be the space craft
        var newCraft = new Texture2D(37,103);
        //set the entire background to transparent
        for(int x = 0; x < newCraft.width; x++){
            for(int y = 0; y < newCraft.height; y++){
                newCraft.SetPixel(x,y, new Color(1,1,1,0));
            }
        }

        //iterate through all sprite for space craft
        for(int i = 0; i < spritesToShip.Length; i++){
            //overlap current sprite to texture
            for(int x = 0; x < spritesToShip[i].texture.width; x++){
                for(int y = 0; y < spritesToShip[i].texture.height; y++){
                    //if statement for in case current sprite has transparent pixel and needs to be overlayed on a color
                    var color = spritesToShip[i].texture.GetPixel(x, y).a == 0 ?
                                    newCraft.GetPixel(x,y) :
                                    spritesToShip[i].texture.GetPixel(x,y);
                    newCraft.SetPixel(x,y, color);
                }
            }
        }
        //apply all changes to texture
        newCraft.Apply();
        //create new sprite for merged ship
        mergedShip = Sprite.Create(newCraft, new Rect(0, 0, newCraft.width, newCraft.height), new Vector2(0.5f, 0.5f));

        //set the second item on sprites to merge to newCraft
        spritesToMerge[1] = mergedShip;

        //get solar upgrade width
        int solarWidth = (int)solarSpriteArray[solarIndex].rect.width;
        //get craft width
        int craftWidth = (int)newCraft.width;

        //create new texture that is the width of both the solar upgrade and newCraft width
        var newTexture = new Texture2D(solarWidth+craftWidth, 103);
        //set the background transparent
        for(int x = 0; x < newTexture.width; x++){
            for(int y = 0; y < newTexture.height; y++){
                newTexture.SetPixel(x,y, new Color(1,1,1,0));
            }
        }

        int xOffset = 0;

        //go through array and start merging sprites from left to right
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

        Sprite[] spritesToMerge = {solarNoBoostArray[solarIndex],craft};

        Sprite[] spritesToShip = {craft, budgetSpriteArray[budgetindex], fuelSpriteArray[fuelIndex]};

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

        int solarWidth = (int)solarSpriteArray[solarIndex].rect.width;
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


    public void modifyUpgradeVisuals()
    {
       // ModifySingleUpgrade("launchers");
        ModifySingleUpgrade("solarPanels");
        ModifySingleUpgrade("fuelEfficiency");
        ModifySingleUpgrade("wealthExpediters");
    }


    public void ModifySingleUpgrade(string upgradeName)
    {
        var upgradeBoolArray = new bool[1];
        switch (upgradeName)
        {
            case "fuelEfficiency":
                upgradeBoolArray = upManage.getUpgradeArray(upgradeName);
                break;
            case "solarPanels":
                upgradeBoolArray = upManage.getUpgradeArray(upgradeName);
                break;
            case "wealthExpediters":
                upgradeBoolArray = upManage.getUpgradeArray(upgradeName);
                break;
            default:
                return;
        }

        getSpriteIndexes(upgradeName, upgradeBoolArray);

    }

    public void getSpriteIndexes(string upgradeNam, bool[] arr)
    {
        switch (upgradeNam)
        {
            case "launchers":
                if (arr[0])
                {

                }

                if (arr[1])
                {
                    // disable launchers1 sprite


                    // enable launchers2 sprite

                }
                if (arr[2])
                {
                    // disbale launchers2 sprite

                    // enable launchers3 sprite

                }
                break;
            case "solarPanels":
                if (arr[0])
                {
                    // enable solar1 sprite
                    solarIndex = 1;

                }

                else
                {
                    solarIndex = 0;
                }
                if (arr[1])
                {
                    // disable solar1 sprite
                    solarIndex = 2;
                    // enable solar2 sprite

                }
                if (arr[2])
                {
                    // disable solar2 sprite
                    solarIndex = 3;
                    // enable solar3 sprite

                }
                break;
            case "fuelEfficiency":
                if (arr[0])
                {
                    // enable fuel1 sprite
                    fuelIndex = 1;
                }
                else
                {
                    fuelIndex = 0;
                }
                if (arr[1])
                {
                    // disbale fuel1 sprite
                    fuelIndex = 2;
                    // enable fuel2 sprite

                }
                if (arr[2])
                {
                    // disbale fuel2 sprite
                    fuelIndex = 3;
                    // enable fuel3 sprite

                }
                break;
            case "wealthExpediters":
                if (arr[0])
                {
                    // enable budget1 sprite
                    budgetindex = 1;

                }
                else
                {
                    budgetindex = 0;
                }
                if (arr[1])
                {
                    // disable budget1 sprite
                    budgetindex = 2;
                    // enable budget2 sprite

                }
                if (arr[2])
                {
                    // disable budget2 sprite
                    budgetindex = 3;
                    // enable budget3 sprite
                    
                }
                break;
            default:
                return;
        }
    }
    //grab correct sprite method for budget
    public Sprite getBudgetSprite(bool[] budgetArray){
        if (budgetArray[0]){
            // enable budget1 sprite
            return budgetSpriteArray[0];
        }
        if (budgetArray[1]){
            // enable budget2 sprite, disable budget1 sprite
            return budgetSpriteArray[1];
        }
        if (budgetArray[2]){
            // enable budget3 sprite, disbale budget2
            return budgetSpriteArray[2];
        }
        else{
            return null;
        }
    }

    //grab correct sprite method for fuel
    public Sprite getFuelSprite(bool[] fuelArray){
        if (fuelArray[0]){
            // enable fuelSprite1
            return fuelSpriteArray[0];
        }
        if (fuelArray[1]){
            // enable fuelSprite2, disable fuelSprite2
            return fuelSpriteArray[1];
        }
        if (fuelArray[2]){
            // enable fuelSprite3, disable fuelSprite2
            return fuelSpriteArray[2];
        }
        else{
            return null;
        }
    }

    //grab correct sprite method for solar
    public Sprite getSolarSprite(bool[] solArray){
        if (solArray[0]){
            // enable solarSprite1
            return solarSpriteArray[0];
        }
        if (solArray[1]){
            // enable solarSprite2, disable solarSprite1
            return solarSpriteArray[1];
        }
        if (solArray[2]){
            // enable solarSprite3, disable solarSprite2
            return solarSpriteArray[2];
        }
        else{
            return null;
        }
    }
}
