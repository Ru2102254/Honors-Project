using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver: MonoBehaviour {

    public void Replay()
    {
        FindFirstObjectByType<AudioManager>().Stop("Death");
        FindFirstObjectByType<AudioManager>().Stop("Win");
        SceneManager.LoadScene("Test Space");
    }

    public void QuitToMenu()
    {
        FindFirstObjectByType<AudioManager>().Stop("Death");
        FindFirstObjectByType<AudioManager>().Stop("Win");
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Player Has Quit");
    }
}
