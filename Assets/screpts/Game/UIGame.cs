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
        
        _gameDifficulty = PlayerPrefs.GetInt(KeyStorage.gameDifficulty);

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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
        SceneManager.LoadScene("UROVNI");
        PlayerPrefs.SetInt(KeyStorage.GameTypeKey, _gameType);
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

        yield return new WaitForSeconds(3.0f);

       
       
        
            RefreshField();
        
    }

    private void PanelsShow(bool active)
    {
        _questionTxt.gameObject.SetActive(active);
        _answerTxt.gameObject.SetActive(active);
        _resultTxt.gameObject.SetActive(!active);
    }
}
