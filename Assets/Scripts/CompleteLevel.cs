using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string nextLevel;

    public int nextLevelIndex;

    public SceneFader sceneFader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Continue()
    {
        PlayerPrefs.SetInt(nextLevel, nextLevelIndex);
        sceneFader.FadeTo(nextLevel);
    }
}
