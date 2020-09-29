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

    public int nextLevel;
  
    // Start is called before the first frame update
    void Start()
    {
        GameisOver = false;
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
        PlayerPrefs.SetInt("levelReached", nextLevel);

    }

}
