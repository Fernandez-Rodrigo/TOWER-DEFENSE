using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        roundText.text = "Waves survived: " + PlayerStats.rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Menu()
    {

    }


}
