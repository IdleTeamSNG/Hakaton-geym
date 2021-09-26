using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lvl1Scr : MonoBehaviour
{
    private int Comix = 0;
    public GameObject TextCont;
    public List<string> txt = new List<string>();
    
    private AudioSource audioSr;
    public GameObject audioSrObj;
    public AudioClip ClicAu;
    
    
    public string endtxt;
    public GameObject wind;
    public Sprite virus;
    public GameObject uimenager;
    public UIGame ui;
    public bool Flag = true;

    // Start is called before the first frame update
    void Start()
    {
        ui = uimenager.GetComponent<UIGame>();
        TextCont.GetComponent<Text>().text = txt[Comix];
        audioSr = audioSrObj.GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {

        if (ui._gameScore == 5 && Flag)
        {
            Flag = false;
            EndLvl();
        }
    }
    public void next()
    {
        audioSr.PlayOneShot(ClicAu);
        if (Comix < 6)
        {
            Comix++;
            TextCont.GetComponent<Text>().text = txt[Comix];
        }
        else if(Comix == 6)
        {
            Comix++;
            wind.SetActive(false);
        }
        else if (Comix == 7)
        {
            Comix++;
            gameObject.GetComponent<Image>().sprite = virus;
            TextCont.GetComponent<Text>().text = "...";
        }
        else if (Comix == 8)
        {
            SceneManager.LoadScene("lvl2");
    
        }



    }
    public void EndLvl()
    {
        wind.SetActive(true);
        TextCont.GetComponent<Text>().text = endtxt;
        
    }
   

}
