using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionState : BaseState
{
    public ActionState(Player player) : base(player) { }

    public override void OnStateEnter()
    {
        player.GetComponent<PlayerMovement>().myturn = true;
        player.GetComponent<PlayerAttack>().myturn = true;
    }

    public override void OnStateExit()
    {

    }

    public override void OnStateUpdate()
    {

    }
}
