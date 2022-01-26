using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RounbutScr : MonoBehaviour
{
    public GameObject Et;
    public void OnEnable()
    {
        Et.GetComponent<EtamScr>().EtClose += onAktClose;
        Et.GetComponent<EtamScr>().EtOpen += onAktOpen;
      


    }
    public void OnDisable()
    {
        Et.GetComponent<EtamScr>().EtClose -= onAktClose;
        Et.GetComponent<EtamScr>().EtOpen -= onAktOpen;
        
    }
    public void onAktClose()
    {
        
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;

    }
    public void onAktOpen()
    {

        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;

    }
}
