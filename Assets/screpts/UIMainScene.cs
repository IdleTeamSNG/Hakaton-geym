using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class UIMainScene : MonoBehaviour
{
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _creditsPanel;

    [SerializeField] private GameObject _gameTypeObj;
    [SerializeField] private bool _gameType;

    private AudioSource audioSr;
    public GameObject audioSrObj;
    public AudioClip ClicAu;
    

    private int gameType; // 0 - single, 1 - multplayer

    private togle _toggler;

   
    private void Awake()
    {
        _toggler = _gameTypeObj.GetComponent<togle>();
    }

    private void OnEnable()
    {
        _toggler.OnToggle += OnToggle;
    }

    private void OnDisable()
    {
        _toggler.OnToggle -= OnToggle;
    }
    private void Start()
    {
        audioSr = audioSrObj.GetComponent<AudioSource>();
        _gameType = _toggler.value;
        ShowMain();
    }

    private void OnToggle(bool multi)
    {
        _gameType = multi;
    }

    private void ShowMain()
    {
        HideLayers();
        _mainPanel.SetActive(true);



        _gameType = false;
        
    }

    private void HideLayers()
    {
        _mainPanel.SetActive(false);
        _settingsPanel.SetActive(false);
        _creditsPanel.SetActive(false);
    }


    // buttons

    public   void OnPlayPress()
    {
        
        int pickedGameType;

        
        
        if (_gameType)
        {
            // multi
            pickedGameType = 1;
        }
        else
        {
            // solo
            pickedGameType = 0;
            
        }
        StartCoroutine(play(pickedGameType));





    }
    IEnumerator play(int pickedGameType)
    {
        audioSr.PlayOneShot(ClicAu);
        yield return new WaitForSeconds(0.3f);
        PlayerPrefs.SetInt(KeyStorage.GameTypeKey, pickedGameType);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnSettingsPress()
    {
        audioSr.PlayOneShot(ClicAu);
        HideLayers();
        _settingsPanel.SetActive(true);
    }

    public void OnCreditsPress()
    {
        audioSr.PlayOneShot(ClicAu);
        HideLayers();
        _creditsPanel.SetActive(true);
    }

    public void OnBackPress()
    {
        audioSr.PlayOneShot(ClicAu);
        ShowMain();
    }

    public void OnExitPress()
    {
        audioSr.PlayOneShot(ClicAu);
        Application.Quit();
    }
}
