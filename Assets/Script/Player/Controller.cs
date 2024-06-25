using Photon.Pun;
using System;
using UnityEngine;

public class Controller : MonoBehaviourPunCallbacks
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnAimEvent;
    public event Action OnGazeEvent;
    public event Action OnFireEvent;


    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnAimEvent?.Invoke(direction);
    }

    public void CallGazeEvent()
    {
        OnGazeEvent?.Invoke();
    }

    public void CallFireEvent()
    {
        OnFireEvent?.Invoke();
    }
}
