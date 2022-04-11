using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreN : MonoBehaviour
{
    private int value;
    List<int> v = new List<int>();
    protected static int answer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //v = GetNewQuestionljgic2Delenie(1, 10, 5);
        //foreach (int elem in v)
        //{
        //    print(elem);
        //}
        //print(answer);


    }

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
        qestion.Add(0);
        return qestion;
    }
    public static List<int> GetNewQuestionljgic1Vichitanie(int dif1, int dif2, int ostatoc1, int ostatoc2, int size)
    {
        answer = 0;
        List<int> qestion = new List<int>();

        int value;
        int vichit;

        int ost;
        int difeerence;
        value = Random.Range(dif1, dif2);
        qestion.Add(value);
        answer += value;
        difeerence = Random.Range(ostatoc1, ostatoc2);
        ost = value - difeerence;
        for (int i = 0; i < size; i++)
        {
            vichit = Random.Range(0, ost - 1);
            ost = ost - vichit;

            qestion.Add(vichit);

            answer -= vichit;
        }

        vichit = ost;
        ost = ost - vichit;

        qestion.Add(vichit);

        answer -= vichit;

        qestion.Add(0);
        return qestion;


    }
    public static List<int> GetNewQuestionljgic2Clojenie(int dif1, int dif2, int size)
    {
        int answerprom = 0;
        int x = 0;

        List<int> qestion = GetNewQuestionljgic1Clojenie(dif1, dif2, size);

        x = Random.Range(0, size);
        answerprom = qestion[x];
        qestion[x] = 0;
        qestion[size] = answer;
        answer = answerprom;
        return qestion;






    }


    public static List<int> GetNewQuestionljgic2Vichitanie(int dif1, int dif2, int ostatoc1, int ostatoc2, int size)
    {
        int answerprom = 0;
        int x = 0;

        List<int> qestion = GetNewQuestionljgic1Vichitanie(dif1, dif2, ostatoc1, ostatoc2, size);
        x = Random.Range(0, size);
        answerprom = qestion[x];
        qestion[x] = 0;
        qestion[size + 2] = answer;
        answer = answerprom;
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
        qestion.Add(0);
        return qestion;

    }
    public static List<int> GetNewQuestionljgic2Umnojenie(int dif1, int dif2, int size)
    {
        int answerprom = 0;
        int x = 0;

        List<int> qestion = GetNewQuestionljgic1Umnojenie(dif1, dif2, size);

        x = Random.Range(0, size);
        answerprom = qestion[x];
        qestion[x] = 0;
        qestion[size] = answer;
        answer = answerprom;
        return qestion;






    }
    public static List<int> GetNewQuestionljgic1Delenie(int dif1, int dif2, int size)
    {
        List<int> qestion = new List<int>();
       

        qestion = GetNewQuestionljgic1Umnojenie( dif1,  dif2,  size);
        qestion[size] = answer;
        answer = qestion[0];
        qestion[0] = 0;
        qestion.Reverse();
        return qestion;


    }
    public static List<int> GetNewQuestionljgic2Delenie(int dif1, int dif2, int size)
    {
        int answerprom = 0;
        int x = 0;

        List<int> qestion = GetNewQuestionljgic1Delenie(dif1, dif2, size);

        x = Random.Range(0, size);
        answerprom = qestion[x];
        qestion[x] = 0;
        qestion[size] = answer;
        answer = answerprom;
        return qestion;
    }




}
