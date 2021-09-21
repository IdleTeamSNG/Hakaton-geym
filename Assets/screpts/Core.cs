using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Core : MonoBehaviour
{
    int answerG;
    
   
    private int randomNumber(int complexity)
    {
        int value = 0;
        bool f = false; 
        while (true)
        {
            if (f)
            {
                return value;
            }
            else
            {
                f = true;
                value = Random.Range(529, 1000);
                value = value * complexity;
                List<int> primal = TrialDivision(value);
                foreach (int item in primal)
                {
                    if (item > 23)
                    {
                        f = false;
                    }
                }
            }
        }


    }


    private List<int> TrialDivision(int n)
    {
        var divides = new List<int>();
        var div = 2;
        while (n > 1)
        {
            if (n % div == 0)
            {
                divides.Add(div);
                n /= div;
            }
            else
            {
                div++;
            }
        }

        return divides;
    }



    public List<int> getNewCase(int complexity, int complexity1)
    {
        int answer = randomNumber(complexity);
        List<int> primeFactor = TrialDivision(answer);
        
        

        answerG = answer;
        for (int j = 0; j < complexity1; j++)
        {
            for (int i = 0; i < primeFactor.Count - 1; i++)
            {
                int value = Random.Range(i + 1, primeFactor.Count);
                primeFactor[i] = primeFactor[i] * primeFactor[value];
                primeFactor.RemoveAt(value);
            }
        }
        
        return primeFactor;

    }


    public bool answer(int check)
    {
        return answerG == check;
    }
}
