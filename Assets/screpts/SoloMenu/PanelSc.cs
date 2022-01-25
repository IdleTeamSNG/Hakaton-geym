using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PanelSc : MonoBehaviour
{
    [SerializeField] private GameObject _gameTypeObj;
    [SerializeField] private bool _gameType;
    private togle _toggler;
    [SerializeField] private Animator animator;
    private static readonly int Value = Animator.StringToHash(name: "Value");
    private void Awake()
    {
        _toggler = _gameTypeObj.GetComponent<togle>();
    }

    private void OnEnable()
    {
        _toggler.OnToggle += OnToggle;
    }

    private void OnDisable()
    {
        _toggler.OnToggle -= OnToggle;
    }
    private void OnToggle(bool multi)
    {
        _gameType = multi;
        animator.SetBool(id: Value, _gameType);
    }


}

