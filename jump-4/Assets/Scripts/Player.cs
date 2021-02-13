using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    //references
    public Score scoreText;
    public GameObject replayBtn;
    public CoinCount coinCount;

    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Column"))
        {
            print("Score up");
            scoreText.ScoreUp();
            scoreText.UpdateBest();
        }

        if(collision.CompareTag("Coin"))
        {
            print("Coin + 1");
            coinCount.CoinCounter();
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
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
