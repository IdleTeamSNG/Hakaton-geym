using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{ 
    Core cr = new Core();
    List<int> Case = new List<int>();
   
    public GameObject txt;
    // Start is called before the first frame update
    void Start()
    {   Case = cr.getNewCase(6, 1);

        for (int i = 0; i < Case.Count - 1; i++)
        {
            Debug.Log(Case[i]);
            if (i == 0)
            {
                txt.GetComponent<Text>().text = txt.GetComponent<Text>().text + System.Convert.ToString(Case[i]) + "x";
            }
            else if(i == (Case.Count - 1))
            {
                txt.GetComponent<Text>().text = txt.GetComponent<Text>().text + System.Convert.ToString(Case[i]) + "=";
            }
            else
            {
                txt.GetComponent<Text>().text = txt.GetComponent<Text>().text + System.Convert.ToString(Case[i]) + "x";
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
