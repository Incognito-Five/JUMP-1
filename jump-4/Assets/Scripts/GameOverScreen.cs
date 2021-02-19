using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text FinalScore;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        FinalScore.text = "Score: " + score.ToString();
    }

    public void ReplayButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
