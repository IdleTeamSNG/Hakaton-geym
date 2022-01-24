using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestCheck : MonoBehaviour
{
    public GameObject targ;
    public void OnDestroy()
    {
        targ.GetComponent<Audio>().OnDestCheck();
    }
}
