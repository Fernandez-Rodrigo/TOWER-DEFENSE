using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameisOver = false;

    public bool isPaused = false;

    public GameObject gameOverCanvas;

    public GameObject pauseCanvas;

    public SceneFader sceneFader;

    public GameObject winCanvas;

  
    // Start is called before the first frame update
    void Start()
    {
        GameisOver = false;
        FindObjectOfType<AudioManager>().Stop("MenuSong");
        FindObjectOfType<AudioManager>().Play("InGameSong");
        FindObjectOfType<AudioManager>().Stop("GameOverSong");
        FindObjectOfType<AudioManager>().Stop("WinGameSong");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameisOver == true)
        {
            return;
        }


        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }


        PauseGame();
    }


    private void EndGame()
    {
        GameisOver = true;
        gameOverCanvas.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("MenuSong");
        FindObjectOfType<AudioManager>().Stop("InGameSong");
        FindObjectOfType<AudioManager>().Play("GameOverSong");
        FindObjectOfType<AudioManager>().Stop("WinGameSong");

    }

    public void PauseGame()
    {
        if (GameisOver == true)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.P) && isPaused == false)
        {
            pauseCanvas.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;
            
            
        }
        else if(Input.GetKeyDown(KeyCode.P) & isPaused == true)
        {
            Time.timeScale = 1;
            isPaused = false;
            pauseCanvas.SetActive(false);
        }
    }

    public void WinLevel()
    {
        GameisOver = true;
        winCanvas.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("MenuSong");
        FindObjectOfType<AudioManager>().Stop("InGameSong");
        FindObjectOfType<AudioManager>().Stop("GameOverSong");
        FindObjectOfType<AudioManager>().Play("WinGameSong");

    }

}
