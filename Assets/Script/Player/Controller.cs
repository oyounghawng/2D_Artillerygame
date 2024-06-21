using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnAimEvent;
    public event Action<float> OnFireEvent;


    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvenet(Vector2 direction)
    {
        OnAimEvent?.Invoke(direction);
    }
    public void CallFireEvent(float value)
    { 
        OnFireEvent?.Invoke(value);
    }
}
