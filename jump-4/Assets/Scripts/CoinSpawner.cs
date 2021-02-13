using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float minY, maxY;
    float timer;
    public float maxTime;

    void Start()
    {
        SpawnCoin();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            int randpos = Random.Range(1, 10);
            if (randpos % 3 == 0)
            {
                SpawnCoin();
            }
            timer = 0;
        }
    }

    void SpawnCoin()
    {
        float randYpos = Random.Range(minY, maxY);

        GameObject newCoin = Instantiate(coinPrefab);
        newCoin.transform.position = new Vector2(
            transform.position.x,
            randYpos);
    }
}
