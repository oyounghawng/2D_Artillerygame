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
    public void OnMove(InputAction.CallbackContext context)
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (!player.myturn)
            return;

        Vector2 moveInput = context.ReadValue<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }
    public void OnAim(InputAction.CallbackContext context)
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (!player.myturn)
            return;

        Vector2 newAim = context.ReadValue<Vector2>();
        CallLookEvent(newAim);
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (!player.myturn)
            return;

        if (context.phase == InputActionPhase.Performed)
        {
            CallGazeEvent();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            CallFireEvent();
        }
    }
}
