using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver: MonoBehaviour {

    public void Replay()
    {
        SceneManager.LoadScene("Test Space");
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }


    
}
