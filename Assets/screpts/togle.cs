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


    private void Awake()
    {
        if(this.animator == null)
        {
            this.animator = GetComponent<Animator>();
        }
    }

    public void Togle()
    {
        this.value = !this.value;
        this.animator.SetBool(id: Value, this.value);
        OnToggle?.Invoke(value);
    }

}
