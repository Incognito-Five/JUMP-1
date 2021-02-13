using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    public GameObject columnPrefab;
    
    public float minY, maxY;

    float timer;
    public float maxTime;
    
    void Start()
    {
        SpawnColumn();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= maxTime)
        {
            SpawnColumn();
            timer = 0;
        }
    }

    void SpawnColumn()
    {
        float randYpos = Random.Range(minY, maxY);

        GameObject newColumn = Instantiate(columnPrefab);
        newColumn.transform.position = new Vector2(
            transform.position.x,
            randYpos);
    }
}
