using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIHubScene : MonoBehaviour
{
    private int _gameType; 

    private void Awake()
    {
    }

    private void Start()
    {
        _gameType = PlayerPrefs.GetInt(KeyStorage.GameTypeKey);
        if(_gameType == 0)
        {
            // show current UI
        }
        else
        {
            // show multiplayer UI
        }

    }

    public void OnTutorialPress()
    {
        SceneManager.LoadScene("Tutor");
    }

    public void OnLevelPress(int index)
    {
        int pickedLevel = index;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        PlayerPrefs.SetInt(KeyStorage.LevelIndexKey, pickedLevel);
        PlayerPrefs.Save();
    }

    public void OnBackPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
