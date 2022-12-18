using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    List<string> qe = new List<string>();
    // Start is called before the first frame update
    void Start()
    {

        qe = CoreN.GetQestion(1, 20, 6, ":");
        for( int i = 0; i<13; i++)
        {
            print(qe[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
