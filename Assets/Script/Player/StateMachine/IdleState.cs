using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(Player player) : base(player) { }

    public override void OnStateEnter()
    {
        player.myturn = false;
        player.GetComponent<Fuel>().ResetFuel();
    }

    public override void OnStateExit()
    {

    }

    public override void OnStateUpdate()
    {

    }
}
