using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgaudioScr : MonoBehaviour
{
    public float Vollum = 0.5f;

    void Start()
    {

        ChangeVall();
    }
    public void ChangeVall()
    {

        if (PlayerPrefs.HasKey("VollMus"))

        {
            Vollum = PlayerPrefs.GetFloat("VollMus");

        }
        gameObject.GetComponent<AudioSource>().volume = Vollum;
    }

}
