using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Text livesText;
    public Text scoreText;
    public GameObject gameOverPanel;
    public Text gameOverText;


    private int lives = 3;
    private int score = 0;

    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
        gameOverPanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
    }


    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true); //show game over panel
        gameOverText.text = "Game Over";
        Time.timeScale = 0;
    }
}