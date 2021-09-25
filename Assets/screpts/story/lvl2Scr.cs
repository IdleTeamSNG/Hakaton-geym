using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class lvl2Scr : MonoBehaviour
{
    private int comix = 0;
    public GameObject txtObj;
    public GameObject uimenager;
    public UIGame ui;
    public GameObject wind;
    public GameObject imageCont;
    public Sprite BigVirus;
    public string txt1;
    public string txt2;
    private bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        txtObj.GetComponent<Text>().text = txt1;
        ui = uimenager.GetComponent<UIGame>();
    }

    // Update is called once per frame
    void Update()
    {
      if (ui._gameScore == 5 && flag)
        {
            wind.SetActive(true);
            txtObj.GetComponent<Text>().text = txt2;
            flag = false;

        }
    }
    public void clic()
    {
        comix++;
        if (comix == 1)
        {
            wind.SetActive(false);
        }
        
        else if (comix == 2)
        {
            
            txtObj.GetComponent<Text>().text = "...";
            imageCont.GetComponent<Image>().sprite = BigVirus;
            

        }
        else if (comix == 3)
        {
            SceneManager.LoadScene("UROVNI");
        }



    }
}
