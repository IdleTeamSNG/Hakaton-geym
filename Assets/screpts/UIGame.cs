using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIGame : MonoBehaviour
{ 
    Core cr = new Core();
    List<int> Case = new List<int>();
   
    [SerializeField] private Text _questionTxt;
    [SerializeField] private Text _answerTxt;
    [SerializeField] private Text _counterTxt;
    [SerializeField] private Text _resultTxt;
    [SerializeField] private Button _sendBtn;
    [SerializeField] private Text _timerText;

    private int _gameDifficulty;
    private int _gameType;
    private int _sportMode;

    private float _timer;

    private int _answer;

    private int _gameCount;
    private int _gameScore;

    void Start()
    {
        _gameType = PlayerPrefs.GetInt(KeyStorage.MultiplayerModeKey);
        _sportMode = PlayerPrefs.GetInt(KeyStorage.SportModeKey);
        _gameDifficulty = PlayerPrefs.GetInt(KeyStorage.LevelIndexKey);

        _gameCount = 0;
        _gameScore = 0;

        SetField();
        RefreshField();

        _timer = _gameDifficulty * 60;

    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        _timerText.text = Mathf.Round(_timer).ToString();

        if(_timer < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void OnSendPress()
    {
        StartCoroutine(ResultShow());
        _gameCount++;

        _sendBtn.interactable = false;
    }

    public void OnButtonPress(int index)
    {
        if (_answer == 0)
        {
            _answer = index;
            _answerTxt.text = index.ToString() + "x";
        }
        else
        {
            _answer *= index;
            _answerTxt.text = _answerTxt.text + index.ToString() + "x";
        }
    }

    public void OnExitPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void SetField()
    {
        if(_gameType == 0 && _sportMode == 0)
        {
            _timerText.gameObject.SetActive(false);
        }
        else
        {
            _timerText.gameObject.SetActive(true);
        }
    }

    private void RefreshField()
    {
        PanelsShow(true);
        _sendBtn.interactable = true;

        _answer = 0;
        _answerTxt.text = "";
        _questionTxt.text = "";

        _counterTxt.text = _gameScore.ToString();

        Case = cr.getNewCase(6, 1);

        for (int i = 0; i < Case.Count; i++)
        {
            Debug.Log(Case[i]);
            if (i == 0)
            {
                _questionTxt.text = _questionTxt.text + System.Convert.ToString(Case[i]) + "x";
            }
            else if (i == (Case.Count - 1))
            {
                _questionTxt.text = _questionTxt.text + System.Convert.ToString(Case[i]) + "=";
            }
            else
            {
                _questionTxt.text = _questionTxt.text + System.Convert.ToString(Case[i]) + "x";
            }
        }
    }

    private IEnumerator ResultShow()
    {
        if (cr.answer(_answer))
        {
            PanelsShow(false);
            _resultTxt.text = "Molodec";
            _gameScore++;
        }
        else
        {
            PanelsShow(false);
            _resultTxt.text = "Ne Molodec";
        }

        yield return new WaitForSeconds(3.0f);

        if(_gameScore == 5 && _gameType == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else
        {
            RefreshField();
        }
    }

    private void PanelsShow(bool active)
    {
        _questionTxt.gameObject.SetActive(active);
        _answerTxt.gameObject.SetActive(active);
        _resultTxt.gameObject.SetActive(!active);
    }
}
