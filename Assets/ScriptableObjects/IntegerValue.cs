using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Integer Value", menuName = "ScriptableObjects/Integer Value", order = 1)]
public class IntegerValue : ScriptableObject
{
    public int value;
    private Action _onValueChanged;

    public int Value
    {
        get { return value; }
        set { SetValue(value); }
    }

    public void SetValue(int value)
    {
        this.value = value;
        _onValueChanged?.Invoke();
    }
    
    public void SubscribeToValueChanged(Action action)
    {
        _onValueChanged += action;
    }
    
    public void UnsubscribeToValueChanged(Action action)
    {
        _onValueChanged -= action;
    }
}
