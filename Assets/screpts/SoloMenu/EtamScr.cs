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
    public event Action EtClose;
    public event Action EtOpen;
    public GameObject Akt;
    
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
        EtOpen?.Invoke();
        animator.SetBool("isOpen", true);
    }
    public void Close()
    {
        EtClose?.Invoke();
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
        Akt.GetComponent<button1>().ActClose += onAktClose;
        Akt.GetComponent<button1>().ActOpen += onAktOpen;
        OpenEtEv += OnOpenOther;


    }
    public void OnDisable()
    {
        Akt.GetComponent<button1>().ActClose -= onAktClose;
        Akt.GetComponent<button1>().ActOpen -= onAktOpen;
        OpenEtEv -= OnOpenOther;
    }
    public void onAktClose()
    {
        Close();
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;

    }
    public void onAktOpen()
    {
        
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;

    }
}
