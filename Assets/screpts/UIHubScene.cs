using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIHubScene : MonoBehaviour
{
    [SerializeField] private Toggle[] _levels;

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


    public void OnPlayPress()
    {
        int pickedLvl;

        for (int i = 0; i < _levels.Length; i++)
        {
            if (_levels[i].isOn)
            {
                if (i == 0)
                {
                    SceneManager.LoadScene("Tutor");
                }
                else
                {

                    pickedLvl = i;
                    PlayerPrefs.SetInt(KeyStorage.LevelIndexKey, pickedLvl);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
            else
            {
                Debug.Log("No lvl picked");
            }
        }

        PlayerPrefs.Save();
    }

    public void OnBackPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
