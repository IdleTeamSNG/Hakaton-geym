using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    List<string> qe = new List<string>();
    // Start is called before the first frame update
    void Start()
    {

        qe = CoreN.crash(CoreN.GetQestion(1, 20, 10, "+"),4,4);
        for( int i = 0; i<21; i++)
        {
            print(qe[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
