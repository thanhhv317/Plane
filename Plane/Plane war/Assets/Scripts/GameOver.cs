using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Text scoreText;
    public Text bestScoreText;
    public Text enemiesDeadText;

	// Use this for initialization
	void Start () {
        scoreText.text = "Score : " + GameManager.score;
        bestScoreText.text = "Best Score : " + PlayerPrefs.GetInt("bestScore");
        enemiesDeadText.text = "Enemied Dead : " + GameManager.enemiesDead;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Restart()
    {
        Application.LoadLevel("Main");
    }
    public void QuitGame()
    {
        Application.LoadLevel("Menu");
    }
}
