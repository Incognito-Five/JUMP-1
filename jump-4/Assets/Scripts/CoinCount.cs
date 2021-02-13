using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    int count;

    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    public void CoinCounter()
    {
        count++;
        GetComponent<Text>().text = count.ToString();
    }
}
