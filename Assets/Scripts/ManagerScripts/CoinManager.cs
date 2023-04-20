using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    public static CoinManager instance { get; private set; }
    [SerializeField] private static int coinCount = 0;

    // If there is an instance, and it's not me, delete myself.
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public int addCoins(int coinsToAdd)
    {
        coinCount = coinCount + coinsToAdd;
        return coinCount;
    }

    public int removeCoins(int coinsToRemove)
    {
        coinCount = coinCount - coinsToRemove;
        return coinCount;
    }

    public int getCoinsCount()
    {
        return coinCount;
    }

    public bool ableToSpend(int coinsToSpend)
    {
        if (coinCount > coinsToSpend)
        {
            return true;
        }
        return false;
    }
}
