using System;
using UnityEngine;

public class togle : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator animator;

    [Header("Settings")]
    [Tooltip("Togle value.")]
    public bool value;

    private AudioSource audioSr;
    public GameObject audioSrObj;
    public AudioClip ClicAu;

    private static readonly int Value = Animator.StringToHash(name: "Value");

    public event Action<bool> OnToggle;


    public void Start()
    {
        audioSr = audioSrObj.GetComponent<AudioSource>();
    }
    private void Awake()
    {
        
        if (this.animator == null)
        {
            this.animator = GetComponent<Animator>();
        }
    }

    public void Togle()
    {
        audioSr.PlayOneShot(ClicAu);
        this.value = !this.value;
        this.animator.SetBool(id: Value, this.value);
        OnToggle?.Invoke(value);
    }

}
