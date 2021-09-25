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
    public GameObject Uimenger;
    public UIGame ui = new UIGame();
    public string endtxt;
    
    // Start is called before the first frame update
    void Start()
    {
        TextCont.GetComponent<Text>().text = txt[Comix];
        audioSr = audioSrObj.GetComponent<AudioSource>();
        ui = Uimenger.GetComponent<UIGame>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void next()
    {
        audioSr.PlayOneShot(ClicAu);
        if (Comix < 6)
        {
            Comix++;
            TextCont.GetComponent<Text>().text = txt[Comix];
        }
        
        
    }
    public void EndLvl()
    {
        TextCont.GetComponent<Text>().text = "endtxt";
    }
}
