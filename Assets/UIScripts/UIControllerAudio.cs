using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class UIControllerAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIControllerAudio Instance;
    private AudioSource music;
    public AudioClip sfxStarGame;
    
    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    public void ClickAundioOn()
    {
        music.PlayOneShot(sfxStarGame);
    }
}
