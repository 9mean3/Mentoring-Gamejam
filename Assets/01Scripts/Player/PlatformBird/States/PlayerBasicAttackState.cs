using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicAttackState : PlayerState
{
    public PlayerBasicAttackState(PlatformBird player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    private Vector2 _dir;
    private float _curTime = 0;

    public override void EnterState()
    {
        base.EnterState();

        _curTime = 0;

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        _dir = mousePos - _player.transform.position;
        _dir.Normalize();
        _player.SetVelocity(_dir.x * 5f, _dir.y * 5f);
    }


    public override void UpdateState()
    {
        base.UpdateState();
        _curTime += Time.deltaTime;
        if(_curTime > 1f)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
