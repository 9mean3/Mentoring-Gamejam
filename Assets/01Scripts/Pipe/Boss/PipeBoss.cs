using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossMode
{
    
}

public class PipeBoss : MonoBehaviour
{
    [HideInInspector] public BossMode CurrentBossMode { get; private set; } = 0;
    [HideInInspector] public PipeBossState IdleState;
    [HideInInspector] public List<PipeBossState> States = new List<PipeBossState>();
    private PipeBossState _currentState;

    public bool IsRandomPattern = false;
    public int CurrentPatternIndex = 0;

    private void Awake()
    {
        Transform stateParent = transform.Find("States");
        foreach (Transform stateTrm in stateParent)
        {
            PipeBossState state = stateTrm.GetComponent<PipeBossState>();
            if (state.GetType() == typeof(PipeBossIdleState))
            {
                IdleState = state;
                continue;
            }
            States.Add(state);
        }

        _currentState = IdleState;
        _currentState.EnterState();
    }

    private void Update()
    {
        _currentState.UpdateState();
        Debug.Log(_currentState.name);
    }

    public void ChangeState(PipeBossState nextState)
    {
        _currentState.ExitState();
        _currentState = nextState;
        _currentState.EnterState();
    }
}
