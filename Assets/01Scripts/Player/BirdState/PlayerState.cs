using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStateEnum
{
    Start,
    Game,
    End,
}

public class PlayerState
{
    protected PlayerStateMachine _stateMachine;
    protected FlappyBird _player;
    protected PlayerState(PlayerStateMachine playerStateMachine, FlappyBird player)
    {
        _stateMachine = playerStateMachine;
        _player = player;
    }

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
