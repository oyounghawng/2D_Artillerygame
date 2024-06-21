using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : Controller
{
    Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }
    public void OnMove(InputValue value)
    {
        if (!player.myturn)
            return;

        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }
    public void OnAim(InputValue value)
    {
        if (!player.myturn)
            return;

        Vector2 newAim = value.Get<Vector2>();
        CallLookEvenet(newAim);
    }

    public void OnFire(InputValue value)
    {
        if (!player.myturn)
            return;

        CallFireEvent(3);
    }
}
