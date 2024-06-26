using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }

    public IdleState IdleState { get; }
    public ActionState ActionState { get; }
    public PlayerStateMachine(Player player)
    {
        Player = player;
        IdleState = new IdleState(player);
        ActionState = new ActionState(player); 
    }
}
