using System;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContainer : MonoBehaviour
{
    [SerializeField] private List<ButtonScript> _buttons;

    public event Action<string> onValueRecieved;

    public event Action onEnterClicked;

    private void OnDestroy()
    {
        foreach(var button in _buttons)
        {
            button.onClick -= RecieveClickedValue;
        }
    }

    public void Start()
    {
        for (int i = 0; i < _buttons.Count; i++)
        {
            _buttons[i].onClick += RecieveClickedValue;
        }
    }

    private void RecieveClickedValue(string value)
    {
        if(value == "answer")
        {
            onEnterClicked?.Invoke();
            return;
        }
        onValueRecieved?.Invoke(value);
    }
}
