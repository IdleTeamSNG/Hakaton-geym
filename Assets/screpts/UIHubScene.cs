using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIHubScene : MonoBehaviour
{
    [SerializeField] private GameObject _normalLayer;
    [SerializeField] private GameObject _sportLayer;
    [SerializeField] private GameObject _multiplayerLayer;
    [SerializeField] private togle _toggler;

    private int _gameType; // 0 normal, 1 multiplayer
    private bool _sportMode;

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
        _gameType = PlayerPrefs.GetInt(KeyStorage.GameTypeKey);
        if(_gameType == 0)
        {
            HideAllLayers();
            _normalLayer.SetActive(true);
            _toggler.gameObject.SetActive(true);
        }
        else
        {
            HideAllLayers();
            _multiplayerLayer.SetActive(true);
            _toggler.gameObject.SetActive(false);
        }

    }

    private void OnToggle(bool sport)
    {
        if (sport)
        {
            _sportMode = true;
            HideAllLayers();
            _sportLayer.SetActive(true);
        }
        else
        {
            _sportMode = false;
            HideAllLayers();
            _normalLayer.SetActive(true);
        }
    }

    public void OnTutorialPress()
    {
        SceneManager.LoadScene("Tutor");
    }

    public void OnLevelPress(int index)
    {
        int pickedLevel = index;
        int sportMode = _sportMode ? 1 : 0;

        if(_gameType == 0 && _sportMode == false) 
        {
            // solo
            PlayerPrefs.SetInt(KeyStorage.MultiplayerModeKey, _gameType);
            PlayerPrefs.SetInt(KeyStorage.SportModeKey, sportMode);
            PlayerPrefs.SetInt(KeyStorage.LevelIndexKey, pickedLevel);
            PlayerPrefs.Save();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if(_gameType == 0 && _sportMode)
        {
            // solo sport
            PlayerPrefs.SetInt(KeyStorage.MultiplayerModeKey, _gameType);
            PlayerPrefs.SetInt(KeyStorage.SportModeKey, sportMode);
            PlayerPrefs.SetInt(KeyStorage.LevelIndexKey, pickedLevel);
            PlayerPrefs.Save();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            // multi
            PlayerPrefs.SetInt(KeyStorage.MultiplayerModeKey, _gameType);
            PlayerPrefs.SetInt(KeyStorage.LevelIndexKey, pickedLevel);
            PlayerPrefs.Save();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


    }

    public void OnBackPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void HideAllLayers()
    {
        _normalLayer.SetActive(false);
        _sportLayer.SetActive(false);
        _multiplayerLayer.SetActive(false);
    }
}
