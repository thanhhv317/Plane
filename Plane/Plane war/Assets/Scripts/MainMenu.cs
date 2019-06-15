using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public AudioSource colide_sound;

    public void PlayGame()
    {
        colide_sound.Play();
        SceneManager.LoadScene("Main");
    }
    public void ExitGame()
    {
        colide_sound.Play();
        Application.Quit();
    }
}
