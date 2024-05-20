using System.Collections.Generic;
using UnityEngine;

public enum PlayerStateEnum
{
    Idle,
    Move,
    Jump,
    Fall,
}

public class PlayerStateMachine : MonoBehaviour
{
    public Dictionary<PlayerStateEnum, PlayerState> StateDictionary = new Dictionary<PlayerStateEnum, PlayerState>();
    private PlayerState _curState;
    public PlayerState CurrentState => _curState;

    public void Initialize(PlayerStateEnum startState)
    {
        _curState = StateDictionary[startState];
        _curState.EnterState();
    }

    public void ChangeState(PlayerStateEnum nextState)
    {
        _curState.ExitState();
        _curState = StateDictionary[nextState];
        _curState.EnterState();
    }

    public void AddState(PlayerStateEnum newStateEnum, PlayerState newState)
    {
        StateDictionary.Add(newStateEnum, newState);
    }
}