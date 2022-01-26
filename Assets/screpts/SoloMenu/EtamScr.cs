using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EtamScr : MonoBehaviour
{
    private Animator animator;
    public GameObject GoAnim;
    public bool isOpen;
    public int EtNumb;
    public static event Action<int> OpenEtEv;
    public void Start()
    {
        animator = GoAnim.GetComponent<Animator>();
    }
    public void OnMouseDown()
    {
        isOpen = !isOpen;
        if (isOpen == true)
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
        OpenEtEv?.Invoke(EtNumb);
        animator.SetBool("isOpen", true);
    }
    public void Close()
    {
        animator.SetBool("isOpen", false);
    }
    public void OnOpenOther(int Akt)
    {
        if (Akt != EtNumb)
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
        OpenEtEv += OnOpenOther;


    }
    public void OnDisable()
    {
        OpenEtEv -= OnOpenOther;
    }
}
