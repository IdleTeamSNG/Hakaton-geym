using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonScript : MonoBehaviour
{
    private Text _text;
    private Button _button;

    private string _value;

    public event Action<string> onClick;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _text = GetComponentInChildren<Text>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ClickHandle);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ClickHandle);
    }

    public void Init(string value)
    {
        _value = value;
        _text.text = value;
    }

    private void ClickHandle()
    {
        onClick?.Invoke(_value);
    }
}
