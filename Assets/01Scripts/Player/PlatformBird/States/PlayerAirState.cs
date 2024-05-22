using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(PlatformBird player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        float inputX = _player.PlayerInput.InputX;
        float moveVelX = inputX * _player.MoveSpeed;
        _player.SetVelocity(moveVelX, _rigidbody.velocity.y);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
