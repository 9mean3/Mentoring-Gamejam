using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState//
{
    public PlayerState(PlatformBird player, PlayerStateMachine stateMachine)
    {
        _player = player;
        _stateMachine = stateMachine;
        _rigidbody = _player.RigidbodyCompo;
    }

    protected PlatformBird _player;
    protected PlayerStateMachine _stateMachine;
    protected Rigidbody2D _rigidbody;

    public virtual void EnterState()
    {

    }

    public virtual void UpdateState()
    {

    }

    public virtual void ExitState()
    {

    }
}
