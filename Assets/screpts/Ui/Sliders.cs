using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Sliders : MonoBehaviour
{
    public GameObject VolMusSlide;
    public GameObject VolAplSlide;
    private float VolMusVallue =  0.5f;
    private float VolAplVallue = 0.5f;
    public Action ChangeVollMus;
    public Action ChangeVollApl;
    public GameObject AuServObj;

    public void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        ChangeVollMus += objs[0].GetComponent<BgaudioScr>().ChangeVall;
        ChangeVollApl += AuServObj.GetComponent<Audio>().ChangeVall;

    }
    public void Start()
    {
        if (PlayerPrefs.HasKey("VollMus"))
        {
            VolMusVallue =  PlayerPrefs.GetFloat("VollMus");
            VolMusSlide.GetComponent<Slider>().value = VolMusVallue;
        }
        else
        {
            VolMusSlide.GetComponent<Slider>().value = VolMusVallue;
        }
        if (PlayerPrefs.HasKey("VollApl"))
        {
            VolAplVallue = PlayerPrefs.GetFloat("VollApl");
            VolAplSlide.GetComponent<Slider>().value = VolAplVallue;
        }
        else
        {
            VolAplSlide.GetComponent<Slider>().value = VolAplVallue;
        }
    }
    public void OnChengeMusVoll()
    {
         VolMusVallue = VolMusSlide.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("VollMus", VolMusVallue);
        ChangeVollMus?.Invoke();
    }
    public void OnChengeAplVoll()
    {
        VolAplVallue = VolAplSlide.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("VollApl", VolAplVallue);
        ChangeVollApl?.Invoke();
    }
    public void OnDisable()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        ChangeVollMus -= objs[0].GetComponent<BgaudioScr>().ChangeVall;
        ChangeVollApl -= AuServObj.GetComponent<Audio>().ChangeVall;
    }
}
