using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    #region Singleton:Game
    public static Game Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion


    [SerializeField] Text[] allCoins;


    public int Coins;

    private void Start()
    {
        UpdateAllCoins();
    }

    public void UseCoins(int amount)
    {
        Coins -= amount;
    }
    public bool HasEnoughCoins(int amount)
    {
        return (Coins >= amount);
    }
    public void UpdateAllCoins()
    {
        for (int i = 0; i < allCoins.Length; i++)
        {
            allCoins[i].text = Coins.ToString();
        }
    }
}
