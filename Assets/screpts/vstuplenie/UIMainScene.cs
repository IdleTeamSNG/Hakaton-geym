using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;


public class UIMainScene : MonoBehaviour
{
    [SerializeField] private GameObject _mainPanel;

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
        
        _mainPanel.SetActive(true);



        _gameType = false;
        
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
        yield return new WaitForSeconds(0.4f);
        SaveScript.StoreIntValue(SaveScript.GameTypeKey, pickedGameType);
        Navigation.NavigateHub();
    }

    public void OnSettingsPress()
    {
        Navigation.NavigateSettings();
    }

    public void OnCreditsPress()
    {
        Navigation.NavigateCredits();
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
