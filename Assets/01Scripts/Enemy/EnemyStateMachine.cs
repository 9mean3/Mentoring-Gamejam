using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine 
{
    public Dictionary<Transform, EnemyState> StateDictionary = new Dictionary<Transform, EnemyState>();
    private EnemyState _curState;

    public void Initialize(Transform startState)
    {
        _curState = StateDictionary[startState];
        _curState.EnterState();
    }

    public void ChangeState(Transform nextState)
    {
        _curState.ExitState();
        _curState = StateDictionary[nextState];
        _curState.EnterState();
    }

    public void AddState(Transform newStateEnum, EnemyState newState)
    {
        StateDictionary.Add(newStateEnum, newState);
    }
}
