using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(PlatformBird player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        _player.PlayerInput.Jump += JumpEvent;
        _player.PlayerInput.BasicAttack += BasicAttackEvent;
    }


    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void ExitState()
    {
        base.ExitState();
        _player.PlayerInput.Jump -= JumpEvent;
        _player.PlayerInput.BasicAttack -= BasicAttackEvent;
    }

    private void JumpEvent()
    {
        if (_player.IsGroundDetected())
        {
            _stateMachine.ChangeState(PlayerStateEnum.Jump);
        }
    }
    
    private void BasicAttackEvent()
    {
        _stateMachine.ChangeState(PlayerStateEnum.BasicAttack);
    }
}
