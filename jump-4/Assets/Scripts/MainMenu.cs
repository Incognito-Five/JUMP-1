using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame ()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void UpgradePlayer()
    {
        SceneManager.LoadScene("Upgrades");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
