﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Sounds 
{
    public string name;

    public AudioClip clip;


    [Range(0f,1f)]
    public float volume;

    [Range(0f,3f)]
    public float pitch;

    public bool loop;

    public AudioSource source;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}