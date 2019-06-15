using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static int score;
    public static int enemiesDead;

    public static bool tap;
    public static bool gameOver;

    public Text scoreText;
    public Text enemiesDeadText;

    public GameObject gameOverPanel;
    public GameObject gamePausePanel;

    // Use this for initialization
    void Start () {
        score = 0;
        enemiesDead = 0;
        tap = false;
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameOver)
        {
            GameOver();
        }

        scoreText.text = "Score : " + score;
        if(score > PlayerPrefs.GetInt("bestScore"))
        {
            PlayerPrefs.SetInt("bestScore", score);
        }
        enemiesDeadText.text = "Enemies Dead : " + enemiesDead;
	}

    public void Tap()
    {
        tap = true;
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
        gamePausePanel.SetActive(false);
    }

}
