using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBG : MonoBehaviour
{
    public float speed;
    public float clampPos;
    [HideInInspector] public Vector3 StartPos;

    void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * speed, clampPos);
        transform.position = StartPos + Vector3.left * newPos;
    }
}
