using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartState : PlayerState
{
    protected PlayerStartState(PlayerStateMachine playerStateMachine, FlappyBird player) : base(playerStateMachine, player)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
