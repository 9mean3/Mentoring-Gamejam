using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(PlatformBird player, PlayerStateMachine stateMachine) : base(player, stateMachine)
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
        float moveVelX = inputX * _player.MoveSpeed * Time.deltaTime;
        _player.SetVelocity(moveVelX, _rigidbody.velocity.y);

        if(Mathf.Abs(inputX) < 0.05f)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}