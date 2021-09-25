using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvl1Scr : MonoBehaviour
{
    private int Comix = 0;
    public GameObject TextCont;
    public List<string> txt = new List<string>();
    private AudioSource audioSr;
    public GameObject audioSrObj;
    public AudioClip ClicAu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void next()
    {
        audioSr.PlayOneShot(ClicAu);
        if (Comix < 4)
        {
            Comix++;
            TextCont.GetComponent<Text>().text = txt[Comix];
        }
        else
        {

        }
    }
}
