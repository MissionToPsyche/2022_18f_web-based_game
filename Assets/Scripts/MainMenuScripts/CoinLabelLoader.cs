using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinLabelLoader : MonoBehaviour
{

    [SerializeField]
    private TMPro.TextMeshProUGUI coinCountText;

    private CoinManager coinManager = new CoinManager();
    // Start is called before the first frame update
    void Start()
    {
        updateCoinText();
    }

    public void updateCoinText(){
        coinCountText.text = coinManager.getCoinsCount() + " coins";
    }

}
