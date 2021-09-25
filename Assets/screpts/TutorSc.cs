using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorSc : MonoBehaviour
{
    private int Comix = 0;
    public GameObject ImageCont;
    public List<Sprite> im = new List<Sprite>();

    public GameObject TextCont;
    public List<string> txt = new List<string>();
    public GameObject Srelka;

    private AudioSource audioSr;
    public GameObject audioSrObj;
    public AudioClip ClicAu;
    // Start is called before the first frame update
    void Start()
    {
        audioSr = audioSrObj.GetComponent<AudioSource>();
        Srelka.SetActive(false);
        ImageCont.GetComponent<Image>().sprite = im[0];
        TextCont.GetComponent<Text>().text = txt[0];
    }

    
    public void back()
    {
        SceneManager.LoadScene("UROVNI");
    }
    public void next()
    {
        audioSr.PlayOneShot(ClicAu);
        if (Comix < 3)
            {
            Comix++;
            ImageCont.GetComponent<Image>().sprite = im[Comix];
            TextCont.GetComponent<Text>().text = txt[Comix];
            }
        else
        {
            SceneManager.LoadScene("Tutor1");
        }
        if (Comix != 0)
        {
            Srelka.SetActive(true);
        }
    }

    public void nenext()
    {
        audioSr.PlayOneShot(ClicAu);
        if (Comix > 0)
        {
            Comix = Comix - 1;
            ImageCont.GetComponent<Image>().sprite = im[Comix];
            TextCont.GetComponent<Text>().text = txt[Comix];
        }
        if (Comix == 0)
        {
            Srelka.SetActive(false);
        }
    }
}
