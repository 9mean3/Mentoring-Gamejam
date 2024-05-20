using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(PlatformBird player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        _player.StopImmediately();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        float inputX = _player.PlayerInput.InputX;

        if(Mathf.Abs(inputX) > 0.05f) 
        {
            _stateMachine.ChangeState(PlayerStateEnum.Move);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
