using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseGame : MonoBehaviour {

    public GameObject gamePausePanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GamePause()
    {
        Time.timeScale = 0;
        gamePausePanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void GameResume()
    {
        Time.timeScale = 1;
        gamePausePanel.SetActive(false);
        gameObject.SetActive(true);
    }
    public void GameQuit()
    {
        Application.LoadLevel("Menu");
    }
}
