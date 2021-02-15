using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text highScore;
    public Text ScoreTxt;

    private int score;
    private int bestScore;

    private void Start()
    {
       if(PlayerPrefs.HasKey("highScore"))
        {
            bestScore = PlayerPrefs.GetInt("highScore");
            highScore.text = bestScore.ToString();
        }

        ScoreTxt.text = "0";
    }

    // Update is called once per frame
    public void ScoreUp()
    {
        score++;
        ScoreTxt.text = score.ToString();

        if (PlayerPrefs.GetInt("highScore") < score)
        {
            PlayerPrefs.SetInt("highScore", score);
            bestScore = PlayerPrefs.GetInt("highScore");
            highScore.text = bestScore.ToString();
        }
    }

    public void ResetScore()
    {
        ScoreTxt.text = "0";
    }
}
