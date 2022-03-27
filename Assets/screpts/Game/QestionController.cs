using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class QestionController : MonoBehaviour
{
    public List<int> qestion;
    public List<string> QestionStrList;
    public string QestionStr;
    public GameObject txt;


    public void Awake()
    {
        LevelJsonController.Qestion += NewQestion;
    }
    public void NewQestion(string Argument) // метод активируется когда сценарий доходит до подачи пользователю задачи. На вход идёт строка параметрв разделены точкой:
                                         // знак(+,-,*,\).тип логики(1,2,3,4).аргумент1.аргумент2.аргумент3.аргумент4(только в -).аргумент5(только в -)
    {
        string[] instruction= Argument.Split('.');
        
        switch (instruction[0], instruction[1])
        {
            case ("+", "1"):
               
                qestion = CoreN.GetNewQuestionljgic1Clojenie(System.Convert.ToInt32(instruction[2]), System.Convert.ToInt32(instruction[3]), System.Convert.ToInt32(instruction[4]));
                QestionStrList = qestion.Select(i => i.ToString()).ToList();
                
                QestionStrList[QestionStrList.IndexOf("0")] = "?";
                
                
                
                QestionStr = String.Join("+", QestionStrList.ToArray(), 0, QestionStrList.Count - 1) + "=" + QestionStrList[QestionStrList.Count - 1]; //готовая строка примера
               
                txt.GetComponent<Text>().text = QestionStr;// тестовый вывод
                


                break;

                


        }
    }
    public void OnDisable()
    {
        LevelJsonController.Qestion -= NewQestion;
    }
}
