using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QestionScr : MonoBehaviour
{
    
    public string Qestion = "eror";
    public int Answer;
    private TextMeshProUGUI _textComp;

    //public void Start()
    //{
    //    gameObject.GetComponent<TextMeshProUGUI>().text = Qestion;// тестовый вывод

    //}
    private void Awake()
    {
        _textComp = GetComponent<TextMeshProUGUI>();
    }

    public void Init(string question, int answer)
    {
        _textComp.text = question;
        Answer = answer;
    }

    public void OnAnswerRecieved(string answer, string stringToReplace)
    {

        _textComp.text = _textComp.text.Replace(stringToReplace, answer);
        Debug.Log(_textComp.text);

    }
   
}
   
