using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    //references
    public GameObject replayBtn;
    public CoinCount coinCount;
    public Score scoreCount;

    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * speed;
            SoundManager.PlaySound(SoundManager.Sound.PlayerJump);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Column"))
        {
            print("Score up");
            scoreCount.ScoreUp();
            SoundManager.PlaySound(SoundManager.Sound.ObstacleScore);

        }

        if (collision.CompareTag("Coin"))
        {
            print("Coin + 1");
            scoreCount.ScoreUp();
            scoreCount.ScoreUp();
            coinCount.CoinCounter();
            SoundManager.PlaySound(SoundManager.Sound.CoinScore);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("Brick"))
        {
            //game over
            Time.timeScale = 0;
            replayBtn.SetActive(true);
            SoundManager.PlaySound(SoundManager.Sound.Lose);

        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("GameScene");
        scoreCount.ResetScore();
    }

}
