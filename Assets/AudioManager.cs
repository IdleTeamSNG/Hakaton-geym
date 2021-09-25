using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip clickSound;
    public AudioClip soloTheme;
    public AudioClip multiTheme;
    public AudioSource mainThemeSource;

    private AudioSource _audio;


    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        int mode = PlayerPrefs.GetInt(KeyStorage.GameTypeKey);
        if(mode == 0)
        {
            mainThemeSource.clip = soloTheme;
        }
        else
        {
            mainThemeSource.clip = multiTheme;
        }
    }

    public void ClickPlay()
    {
        _audio.clip = clickSound;
        _audio.Play();
    }

    public void SoloTheme()
    {
        _audio.clip = soloTheme;
        _audio.Play();
    }

    public void MultiTheme()
    {
        _audio.clip = multiTheme;
        _audio.Play();
    }
}
