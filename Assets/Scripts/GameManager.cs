using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameisOver = false;


    public GameObject gameOverCanvas;

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
    }


    private void EndGame()
    {
        GameisOver = true;
        gameOverCanvas.SetActive(true);
        
    }
}
