using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public PlayerState(PlatformBird player, PlayerStateMachine stateMachine)
    {
        player = _player;
        stateMachine = _stateMachine;
    }

    PlatformBird _player;
    PlayerStateMachine _stateMachine;

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
