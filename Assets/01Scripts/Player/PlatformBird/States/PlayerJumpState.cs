using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(PlatformBird player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        _player.SetVelocity(_rigidbody.velocity.x, _player.JumpPower);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if(_rigidbody.velocity.y < 0)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Fall);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}