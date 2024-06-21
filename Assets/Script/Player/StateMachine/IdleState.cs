using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(Player player) : base(player) { }

    public override void OnStateEnter()
    {
        player.GetComponent<PlayerMovement>().myturn = false;
        player.GetComponent<PlayerAttack>().myturn = false;
    }

    public override void OnStateExit()
    {

    }

    public override void OnStateUpdate()
    {

    }
}
