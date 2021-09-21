using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Core : MonoBehaviour
{
    int answerG;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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



    public (List<string>, int) getNewCase(int complexity)
    {
        int answer = randomNumber(complexity);
        List<int> primeFactor = TrialDivision(answer);
        ;
        int leght = 0;

        answerG = answer;
        for (int j = 0; j < 1; j++)
        {
            for (int i = 0; i < primeFactor.Count - 1; i++)
            {
                int value = Random.Range(i + 1, primeFactor.Count);
                primeFactor[i] = primeFactor[i] * primeFactor[value];
                primeFactor.RemoveAt(value);
            }
        }
        List<string> Case = new List<string>(primeFactor.Count);
        for (int i = 0; i < primeFactor.Count; i++)
        {
            Case[i] = System.Convert.ToString(primeFactor[i]);
        }
        leght = Case.Count;
        return (Case, leght);

    }
}
