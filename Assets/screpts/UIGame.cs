using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{ 
    Core cr = new Core();
    List<int> Case = new List<int>();
   
    [SerializeField] private Text _questionTxt;
    [SerializeField] private Text _answerTxt;

    private int _answer;
    private string _playerAnswer;

    void Start()
    {   
        Case = cr.getNewCase(6, 1);

        for (int i = 0; i < Case.Count; i++)
        {
            Debug.Log(Case[i]);
            if (i == 0)
            {
                _questionTxt.text = _questionTxt.text + System.Convert.ToString(Case[i]) + "x";
            }
            else if(i == (Case.Count - 1))
            {
                _questionTxt.text = _questionTxt.text + System.Convert.ToString(Case[i]) + "=";
            }
            else
            {
                _questionTxt.text = _questionTxt.text + System.Convert.ToString(Case[i]) + "x";
            }
        }

    }

    public void OnSendPress()
    {
        if (cr.answer(_answer))
        {
            Debug.Log("Molodec!");
        }
        else
        {
            Debug.Log("loh-pdr");
        }
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
}
