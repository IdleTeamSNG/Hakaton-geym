using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip clickSound;
    public AudioSource mainThemeSourceMulti;
    public AudioSource mainThemeSourceSolo;


    private AudioSource _audio;


    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        
    }

    public void ClickPlay()
    {
        _audio.clip = clickSound;
        _audio.Play();
    }

   
}
