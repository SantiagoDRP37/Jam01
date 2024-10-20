using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerAudio : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource music;
    public AudioClip sfxStarGame;


    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    public void ClickAundioOn()
    {
        music.Play();
    }
}
