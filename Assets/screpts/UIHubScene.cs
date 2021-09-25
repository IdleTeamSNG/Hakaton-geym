using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class UIHubScene : MonoBehaviour
{
    [SerializeField] private GameObject _normalLayer;
    [SerializeField] private GameObject _sportLayer;
    [SerializeField] private GameObject _multiplayerLayer;
    [SerializeField] private togle _toggler;

    private AudioSource audioSr;
    public GameObject audioSrObj;
    public AudioClip ClicAu;

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
        audioSr = audioSrObj.GetComponent<AudioSource>();
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
        audioSr.PlayOneShot(ClicAu);
        int pickedLevel = index;
        int sportMode = _sportMode ? 1 : 0;

        if(_gameType == 0 && _sportMode == false) 
        {
            // solo
            PlayerPrefs.SetInt(KeyStorage.MultiplayerModeKey, _gameType);
            PlayerPrefs.SetInt(KeyStorage.SportModeKey, sportMode);
            PlayerPrefs.SetInt(KeyStorage.LevelIndexKey, pickedLevel);
            PlayerPrefs.Save();

            StartCoroutine(playgame());
        }
        else if(_gameType == 0 && _sportMode)
        {
            // solo sport
            PlayerPrefs.SetInt(KeyStorage.MultiplayerModeKey, _gameType);
            PlayerPrefs.SetInt(KeyStorage.SportModeKey, sportMode);
            PlayerPrefs.SetInt(KeyStorage.LevelIndexKey, pickedLevel);
            PlayerPrefs.Save();

            StartCoroutine(playgame());
        }
        else
        {
            // multi
            PlayerPrefs.SetInt(KeyStorage.MultiplayerModeKey, _gameType);
            PlayerPrefs.SetInt(KeyStorage.LevelIndexKey, pickedLevel);
            PlayerPrefs.Save();

            StartCoroutine(playMultigame());
        }


    }
    IEnumerator playgame()
    {
        audioSr.PlayOneShot(ClicAu);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator playMultigame()
    {
        audioSr.PlayOneShot(ClicAu);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("GameScenóMulti");
    }

        public void OnBackPress()
    {
        StartCoroutine(back());
    }
    IEnumerator back()
    {
        audioSr.PlayOneShot(ClicAu);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }


    private void HideAllLayers()
    {
        _normalLayer.SetActive(false);
        _sportLayer.SetActive(false);
        _multiplayerLayer.SetActive(false);
    }
}
