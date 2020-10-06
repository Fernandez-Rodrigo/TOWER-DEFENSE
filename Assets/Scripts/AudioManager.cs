using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(gameObject);

        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.pitch = s.pitch;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Play("MenuSong");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);

        if(s == null)
        {
            return;
        }
        s.source.Play();

    }


    public void Stop(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);

        if(s == null)
        {
            return;
        }

        s.source.Stop();
    }
}
