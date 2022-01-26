using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class button1 : MonoBehaviour
{
    private Animator animator;
    public GameObject GoAnim;
    public bool isOpen;
    public int AktNumb;
    public static event Action<int> OpenEv;
    public  event Action ActClose;
    public event Action ActOpen;
    public void Start()
    {
        animator = GoAnim.GetComponent<Animator>();
    }
    public void OnMouseDown()
    {
        isOpen = !isOpen;
        if(isOpen == true)
        {
            Open();
        }
        else
        {
            Close();
        }
        Debug.Log("ok");
    }
    public void Open()
    {
        ActOpen?.Invoke();
        OpenEv?.Invoke(AktNumb);
        animator.SetBool("isOpen", true);
    }
    public void Close()
    {
        ActClose?.Invoke();
       animator.SetBool("isOpen", false);
    }
    public void OnOpenOther(int Akt)
    {
        if (Akt != AktNumb)
        {
            if (isOpen)
            {
                isOpen = false;
                Close();
            }
        }
    }
    public void OnEnable()
    {
        OpenEv += OnOpenOther;


    }
    public void OnDisable()
    {
        OpenEv -= OnOpenOther;
    }
}
