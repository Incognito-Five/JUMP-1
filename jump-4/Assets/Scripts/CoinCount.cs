using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    private int coinCount = 0;
    private int coinCount2 = 0;

    public Text coin;

    void Start()
    {
        if (PlayerPrefs.HasKey("coin"))
        {
            coinCount2 = PlayerPrefs.GetInt("coin");
            coin.text = coinCount2.ToString();
        }
    }

    // Update is called once per frame
    public void CoinCounter()
    {
        coinCount2++;
        PlayerPrefs.SetInt("coin", coinCount2);
        coinCount = PlayerPrefs.GetInt("coin");
        coin.text = coinCount.ToString();

    }

}
