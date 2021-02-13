using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score, bestScore;

    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    public void ScoreUp()
    {
        score++;
        GetComponent<Text>().text = score.ToString();
        UpdateBest();
    }

    public void UpdateBest()
    {
        if (score > bestScore)
        {
            bestScore = score;
            GetComponent<Text>().text = bestScore.ToString();
        }
    }
}
