using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public PlayerState(PlatformBird player, PlayerStateMachine stateMachine)
    {
        player = _player;
        stateMachine = _stateMachine;
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
