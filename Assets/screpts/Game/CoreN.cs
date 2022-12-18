using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreN : MonoBehaviour
{
    private int value;
    List<int> v = new List<int>();
    public static int answer = 0;

    private string _questionMark;

    public static List<int> GetNewQuestionljgic1Clojenie(int dif1, int dif2, int size)
    {
        answer = 0;
        List<int> qestion = new List<int>();
        for (int i = 0; i < size; i++)
        {
            int value;
            value = Random.Range(dif1, dif2);
            qestion.Add(value);
            answer += value;
        }
        qestion.Add(answer);
        return qestion;
    }
   
    public static List<int> GetNewQuestionljgic1Umnojenie(int dif1, int dif2, int size)
    {

        answer = 1;
        List<int> qestion = new List<int>();
        for (int i = 0; i < size; i++)
        {
            int value;
            value = Random.Range(dif1, dif2);
            qestion.Add(value);
            answer *= value;

        }
        qestion.Add(answer);
        return qestion;

    }
    
    public static List<string> ZnakContain(List<int> preqestion, int size, string znak)
    {
        List<string> qestion = new List<string>();
        for (int i = 0; i < size + 1; i++)
        {
            qestion.Add(System.Convert.ToString(preqestion[i]));
            if (i == size - 1)
            {
                qestion.Add("=");
            }
            else if (i != size)
            {
                qestion.Add(znak);
            }
            

        }
        return qestion;
    }
    public static List<string> GetQestion(int dif1, int dif2, int size, string znak)
    {
        List<string> qestion = new List<string>();
        List<int> preqestion = new List<int>();

        switch (znak)
        {
            case ("+"):
                preqestion = GetNewQuestionljgic1Clojenie(dif1, dif2, size);
                qestion = ZnakContain(preqestion, size, znak);
                
                
                break;
            case ("-"):
                preqestion = GetNewQuestionljgic1Clojenie(dif1, dif2, size);
                preqestion.Reverse();
                qestion = ZnakContain(preqestion, size, znak);


                break;
            case ("*"):
                preqestion = GetNewQuestionljgic1Umnojenie(dif1, dif2, size);
                qestion = ZnakContain(preqestion, size, znak);

                break;
            case (":"):
                preqestion = GetNewQuestionljgic1Umnojenie(dif1, dif2, size);
                preqestion.Reverse();
                qestion = ZnakContain(preqestion, size, znak);
                break;



        }


        return qestion;
    }
    public static List<string> crash(List<string> qestion, int type, int colvo)

    {
        int value = 0;


        int size = qestion.Count;
        int SizeZnak = ((size - 1) / 2) - 1;
        int SizeChisl = ((size + 1) / 2) -1 ;
        int AnswInd = size - 1;
        for (int i = 0; i < colvo; i++)
        {
            switch (type)
            {
            
                case (1):
                    if (qestion[AnswInd] == "?")
                    {
                        type = Random.Range(1, 3);
                        colvo += 1;
                        break;
                    }
                     qestion[AnswInd] = "?";
                break;
                case (2):
                    
                    value = Random.Range(0, SizeChisl);
                value += 1;
                value = (value * 2) - 1;
                value -= 1;
                if (qestion[value] == "?")
                {

                    colvo += 1;
                    break;
                }
                    qestion[value] = "?";
                break;
                case (3):
                    value = Random.Range(0, SizeZnak);
                value = value * 2 + 1;
                if (qestion[value] == "!")
                {

                    colvo += 1;
                    break;
                }
                    qestion[value] = "!";
                break;
                case (4):
                    for (int j = 0;j< colvo; j++)
                { 
                    value = Random.Range(0, 4);
                    qestion = crash(qestion, value, 1);
                }
                break;
                }
















        }
        return qestion;

        
    }

}
