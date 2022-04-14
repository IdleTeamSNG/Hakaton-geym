using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using TMPro;

public class QestionController : MonoBehaviour
{
    public GameObject QestionObj;
    public GameObject SpawnObj;
    public List<int> qestion;
    
    public string QestionStr;
    public GameObject txt;
    public string JsonComand;


    public void Awake()
    {
        LevelJsonController.Qestion += JsonIn;
    }
    public void OnDisable()
    {
        LevelJsonController.Qestion -= JsonIn;
    }

    public void JsonIn(string Argument)
    {
        JsonComand = Argument;
        NewQestion(JsonComand);
    }
    public void NewQestion(string Argument) // метод активируетс€ когда сценарий доходит до подачи пользователю задачи. Ќа вход идЄт строка параметрв разделены точкой:
                                         // знак(+,-,*,\).тип логики(1,2,3,4).аргумент1.аргумент2.аргумент3.аргумент4(только в -).аргумент5(только в -)
    {
        string[] instruction= Argument.Split('.');
        
        switch (instruction[0], instruction[1])
        {
            case ("+", "1"):
               
                qestion = CoreN.GetNewQuestionljgic1Clojenie(System.Convert.ToInt32(instruction[2]), System.Convert.ToInt32(instruction[3]), System.Convert.ToInt32(instruction[4]));

                break;
            case ("+", "2"):

                qestion = CoreN.GetNewQuestionljgic2Clojenie(System.Convert.ToInt32(instruction[2]), System.Convert.ToInt32(instruction[3]), System.Convert.ToInt32(instruction[4]));

                break;
            case ("-", "1"):

                qestion = CoreN.GetNewQuestionljgic1Vichitanie(System.Convert.ToInt32(instruction[2]), System.Convert.ToInt32(instruction[3]), System.Convert.ToInt32(instruction[4]), System.Convert.ToInt32(instruction[5]), System.Convert.ToInt32(instruction[6]));

                break;
            case ("-", "2"):

                qestion = CoreN.GetNewQuestionljgic2Vichitanie(System.Convert.ToInt32(instruction[2]), System.Convert.ToInt32(instruction[3]), System.Convert.ToInt32(instruction[4]), System.Convert.ToInt32(instruction[5]), System.Convert.ToInt32(instruction[6]));

                break;
            case ("*", "1"):

                qestion = CoreN.GetNewQuestionljgic1Umnojenie(System.Convert.ToInt32(instruction[2]), System.Convert.ToInt32(instruction[3]), System.Convert.ToInt32(instruction[4]));

                break;
            case ("*", "2"):

                qestion = CoreN.GetNewQuestionljgic2Umnojenie(System.Convert.ToInt32(instruction[2]), System.Convert.ToInt32(instruction[3]), System.Convert.ToInt32(instruction[4]));

                break;
            case ("%", "1"):

                qestion = CoreN.GetNewQuestionljgic1Delenie(System.Convert.ToInt32(instruction[2]), System.Convert.ToInt32(instruction[3]), System.Convert.ToInt32(instruction[4]));

                break;
            case ("%", "2"):

                qestion = CoreN.GetNewQuestionljgic2Delenie(System.Convert.ToInt32(instruction[2]), System.Convert.ToInt32(instruction[3]), System.Convert.ToInt32(instruction[4]));

                break;







        }
        QestionStr = Prepare(qestion, instruction[0]);
        
        SpawnObj = Instantiate(QestionObj);
        SpawnObj.GetComponent<QestionScr>().Qestion = QestionStr;
        SpawnObj.GetComponent<QestionScr>().Answer = CoreN.answer;
        


    }

    

    public string Prepare(List<int> qestion, string znak) // форматирование строки до нормального сото€ни€ дл€ вывода
    {
        List<string> QestionStrList;
        string QestionStr;
        QestionStrList = qestion.Select(i => i.ToString()).ToList();

        QestionStrList[QestionStrList.IndexOf("0")] = "?";



        QestionStr = String.Join(znak, QestionStrList.ToArray(), 0, QestionStrList.Count - 1) + "=" + QestionStrList[QestionStrList.Count - 1]; //готова€ строка примера
        return QestionStr;
    }

    public void Done() // функци€ запускаема€ когда на пример дан верный ответ, запускает дальнейшие елементы сценари€
    {
        LevelJsonController.NextQest();
    }
}
