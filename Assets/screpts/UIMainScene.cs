using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainScene : MonoBehaviour
{
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _creditsPanel;

    [SerializeField] private Toggle[] _gameType;

    private int gameType; // 0 - single, 1 - multplayer
    private readonly string GameTypeKey;

    private void Start()
    {
        ShowMain();
    }

    private void ShowMain()
    {
        HideLayers();
        _mainPanel.SetActive(true);

        foreach(Toggle tg in _gameType)
        {
            tg.isOn = false;
        }
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

        for(int i = 0; i < _gameType.Length; i++)
        {
            if (_gameType[i].isOn)
            {
                pickedGameType = i;
                PlayerPrefs.SetInt(GameTypeKey, pickedGameType);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Debug.Log("No lvl picked");
            }
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
