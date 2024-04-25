using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState CurrentState { get; private set; }
    public Dictionary<PlayerStateEnum, PlayerState> StateDictionary = new Dictionary<PlayerStateEnum, PlayerState>();

    public void ChangeState(PlayerStateEnum nextState)
    {
        CurrentState.ExitState();
        CurrentState = StateDictionary[nextState];
        CurrentState.EnterState();
    }
}
