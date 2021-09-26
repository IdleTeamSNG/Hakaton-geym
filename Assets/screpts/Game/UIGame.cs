using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIGame : MonoBehaviour
{ 
    Core cr = new Core();
    List<int> Case = new List<int>();

    [Header("Result UI Components")]
    [SerializeField] private GameObject _face;
    [SerializeField] private Text _finsalScoreText;

    [Header("UI Components")]
    [SerializeField] private Text _questionTxt;
    [SerializeField] private Text _answerTxt;
    [SerializeField] private Text _counterTxt;
    [SerializeField] private Text _resultTxt;
    [SerializeField] private Button _sendBtn;
    [SerializeField] private Text _timerText;

    private AudioSource audioSr;
    public GameObject audioSrObj;
    public AudioClip ClicAu;

    private int _gameDifficulty;
    public int _gameType;
    public int _sportMode;

    private float _timer;

    private int _answer;

    private int _gameCount;
    public int _gameScore;
    
    
    
    public int dif1;
    public int dif2;


    void Start()
    {
        
        Destroy(GameObject.FindGameObjectWithTag("music"));
        audioSr = audioSrObj.GetComponent<AudioSource>();

        _gameDifficulty = SaveScript.GetStoredInt(SaveScript.GameDifficulty);

        _gameCount = 0;
        _gameScore = 0;

        SetField();
        RefreshField();

        _timer = _gameDifficulty;

    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        _timerText.text = Mathf.Round(_timer).ToString();

        if(_timer < 0 && _sportMode == 1)
        {
            
                SaveScore();
            
            StartCoroutine(SportRoundEnd());
        }
    }

    public void OnSendPress()
    {
        audioSr.PlayOneShot(ClicAu);
        StartCoroutine(ResultShow());
        _gameCount++;
        _counterTxt.text = _gameScore.ToString();

        _sendBtn.interactable = false;
    }

    public void OnButtonPress(int index)
    {
        audioSr.PlayOneShot(ClicAu);
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
        Navigation.NavigateHub();
        SaveScript.StoreIntValue(SaveScript.GameTypeKey, _gameType);
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


        _face.SetActive(true);
        _finsalScoreText.gameObject.SetActive(false);
    }

    private void RefreshField()
    {
        PanelsShow(true);
        _sendBtn.interactable = true;

        _answer = 0;
        _answerTxt.text = "";
        _questionTxt.text = "";

        _counterTxt.text = _gameScore.ToString();

        Case = cr.getNewCase(dif1, dif2);

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

        yield return new WaitForSeconds(1);       
       
        
            RefreshField();
        
    }

    private void PanelsShow(bool active)
    {
        _questionTxt.gameObject.SetActive(active);
        _answerTxt.gameObject.SetActive(active);
        _resultTxt.gameObject.SetActive(!active);
    }

    private IEnumerator SportRoundEnd()
    {
        _timerText.gameObject.SetActive(false);
        yield return new WaitForSeconds(4.0f);
        Navigation.NavigateHub();
    }

    private void SaveScore()
    {
        int currentBest = SaveScript.GetBestScore(_gameDifficulty);

        _face.SetActive(false);
        _finsalScoreText.gameObject.SetActive(true);
        if (_gameType == 0)
        {
            if (_gameScore > currentBest)
            {
                SaveScript.SaveBestScore(_gameDifficulty, _gameScore);
                _finsalScoreText.text = "You have new best: " + _gameScore;
            }
            else
            {
                _finsalScoreText.text = "Your Score: " + _gameScore;
            }
        }

        
        
    }
}
