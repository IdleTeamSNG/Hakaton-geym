using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui : MonoBehaviour
{
    Core cr = new Core();
    List<int> Case = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        Case = cr.getNewCase(2);
        foreach (int item in Case)
        {
            Debug.Log(item);
        }
           ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
