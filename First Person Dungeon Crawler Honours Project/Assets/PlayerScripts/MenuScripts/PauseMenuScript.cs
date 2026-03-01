using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;
    public GameObject PauseBackGroundCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !DataCarryScript.instance.inbattleData && !PauseMenuCanvas.activeSelf)
        {
            Stop();
        }
    }

    void Stop()
    {
        PauseBackGroundCanvas.SetActive(true);
        PauseMenuCanvas.SetActive(true);
        
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Resume()
    {
        PauseBackGroundCanvas.SetActive(false);
        PauseMenuCanvas.SetActive(false);
        
        Time.timeScale = 1f;
        Paused = false;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");  

    }

}
