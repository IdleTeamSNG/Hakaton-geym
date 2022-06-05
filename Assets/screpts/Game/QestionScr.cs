using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class QestionScr : MonoBehaviour
{
    
    public string Qestion = "eror";
    public int Answer;
    private TextMeshProUGUI _textComp;
    private int _replaceIndex = 1;
    private int _questionMarkIndex = 0;
    private bool _firstIteration = true;

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
        _questionMarkIndex = question.IndexOf("?");
    }

    public void OnAnswerRecieved(string answer)
    {
        var builder = new StringBuilder(_textComp.text);
        builder.Remove(_questionMarkIndex, _replaceIndex);
        builder.Insert(_questionMarkIndex, answer);
        _textComp.text = builder.ToString();

        if (_firstIteration)
            _firstIteration = false;
        else
            _replaceIndex++;

    }
   
}
   
