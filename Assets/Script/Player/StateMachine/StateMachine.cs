using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    protected BaseState currentState;

    public void ChangeState(BaseState state)
    {
        currentState?.OnStateExit();
        currentState = state;
        currentState.OnStateEnter();
    }

    public void Update()
    {
        currentState?.OnStateUpdate();
    }

}
