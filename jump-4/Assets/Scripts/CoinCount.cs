using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    private int coinCount;

    public Text coin;

    void Start()
    {
        if(PlayerPrefs.HasKey("coin"))
        {
            coinCount = PlayerPrefs.GetInt("coin");
            coin.text = coinCount.ToString();
        }
    }

    // Update is called once per frame
    public void CoinCounter()
    {
        coinCount++;
        coin.text = coinCount.ToString();
    }
}
