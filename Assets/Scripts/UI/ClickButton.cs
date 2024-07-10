using System;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public event Action Clicked;

    public void Click()
    {
        Clicked?.Invoke();
    }
}
