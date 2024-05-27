using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBasicAttackState : PlayerState
{
    public PlayerBasicAttackState(PlatformBird player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    private Vector3 _dir;
    private Vector2 _attackCenter;

    private float _curTime = 0;
    private LayerMask _enemyLayer = LayerMask.NameToLayer("Enemy");

    public override void EnterState()
    {
        base.EnterState();

        _curTime = 0;

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        _dir = mousePos - _player.transform.position;
        _dir.Normalize();
        _player.SetVelocity(_dir.x * 3f, _dir.y * 3.5f);

        _attackCenter = _player.transform.position + _dir *_player.BasicAtkDistance;
        _player.tstcenter = _attackCenter;
    }


    public override void UpdateState()
    {
        base.UpdateState();
/*
        RaycastHit2D[] hits = 

        foreach (var hit in hits)
        {
            Debug.Log(hit.transform.name);
        }*/

        _curTime += Time.deltaTime;
        if (_curTime > _player.BasicAtkSpeed)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    private void AttackEvent()
    {

    }
}
