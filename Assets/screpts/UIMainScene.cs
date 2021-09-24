using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainScene : MonoBehaviour
{
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _creditsPanel;

    [SerializeField] private GameObject _gameTypeObj;
    [SerializeField] private bool _gameType;
    private int gameType; // 0 - single, 1 - multplayer

    private void Start()
    {
        _gameType = _gameTypeObj.GetComponent<togle>().value;
        ShowMain();
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

    public void OnPlayPress()
    {
        int pickedGameType;

        
        
        if (_gameType)
        {
            pickedGameType = 1;
            PlayerPrefs.SetInt(KeyStorage.GameTypeKey, pickedGameType);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            pickedGameType = 0;
            PlayerPrefs.SetInt(KeyStorage.GameTypeKey, pickedGameType);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
           
        

        PlayerPrefs.Save();        
    }

    public void OnSettingsPress()
    {
        HideLayers();
        _settingsPanel.SetActive(true);
    }

    public void OnCreditsPress()
    {
        HideLayers();
        _creditsPanel.SetActive(true);
    }

    public void OnBackPress()
    {
        ShowMain();
    }

    public void OnExitPress()
    {
        Application.Quit();
    }
}
