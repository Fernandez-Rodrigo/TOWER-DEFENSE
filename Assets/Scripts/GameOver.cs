using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    

    public SceneFader sceneFader;

    public string loadLevel = "MainScene";

    public string loadMenu = "MainMenu";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 
    public void Retry()
    {
        sceneFader.FadeTo(loadLevel);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        sceneFader.FadeTo(loadMenu);
        Time.timeScale = 1;
    }


}
