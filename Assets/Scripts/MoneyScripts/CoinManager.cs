using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    [SerializeField] private static int coinCount = 0;

    // Start is called before the first frame update
    /*
    void Start()
    {
        
    }
    */

    /* Update is called once per frame
    void Update()
    {
        
    }
    */

    public int addCoins(int coinsToAdd){
        coinCount = coinCount + coinsToAdd;
        return coinCount;
    }

    public int removeCoins(int coinsToRemove){
        coinCount = coinCount - coinsToRemove;
        return coinCount;
    }

    public int getCoinsCount(){
        return coinCount;
    }

    public bool ableToSpend(int coinsToSpend){
        if(coinCount > coinsToSpend){
            return true;
        }
        return false;
    }
}
