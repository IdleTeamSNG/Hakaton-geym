using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QestionScr : MonoBehaviour
{
    
    public string Qestion = "eror";
    public int Answer;
    public void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = Qestion;// тестовый вывод
        
    }
   
}
   
