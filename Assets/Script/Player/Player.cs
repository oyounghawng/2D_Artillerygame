using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStateMachine stateMachine;

    private void Awake()
    {
        stateMachine = new PlayerStateMachine(this);
    }
    public void ChangeAction()
    {
        stateMachine.ChangeState(stateMachine.ActionState);
    }

    public void ChangeIdle()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
    }
}
