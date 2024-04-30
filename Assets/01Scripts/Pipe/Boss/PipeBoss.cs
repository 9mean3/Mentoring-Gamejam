using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBoss : MonoBehaviour
{
    [HideInInspector] public PipeBossState IdleState;
    private List<PipeBossState> _states = new List<PipeBossState>();
    private PipeBossState _currentState;

    private void Awake()
    {
        Transform stateParent = transform.Find("States");
        foreach (Transform stateTrm in stateParent)
        {
            PipeBossState state = stateTrm.GetComponent<PipeBossState>();
            if (state.name == "PipeBossIdleState")
            {
                IdleState = state;
                continue;
            }
            _states.Add(state);
        }

        _currentState = IdleState;
    }

    private void Update()
    {
        _currentState.UpdateState();
    }

    public void ChangeState(PipeBossState nextState)
    {
        _currentState.ExitState();
        _currentState = nextState;
        _currentState.EnterState();
    }
}
