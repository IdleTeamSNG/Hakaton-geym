using System;
using UnityEngine;

public class togle : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator animator;

    [Header("Settings")]
    [Tooltip("Togle value.")]
    public bool value;

    
    
   

    private static readonly int Value = Animator.StringToHash(name: "Value");

    public event Action<bool> OnToggle;
    public GameObject AuServ;


    
    private void Awake()
    {
        AuServ.GetComponent<Audio>().PlayClick();
        if (this.animator == null)
        {
            this.animator = GetComponent<Animator>();
        }
    }

    public void Togle()
    {
        AuServ.GetComponent<Audio>().PlayClick();
       
        this.value = !this.value;
        this.animator.SetBool(id: Value, this.value);
        OnToggle?.Invoke(value);
    }

}
