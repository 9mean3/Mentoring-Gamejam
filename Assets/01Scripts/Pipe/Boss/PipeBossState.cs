using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PipeBossState : MonoBehaviour
{
    protected PipeBoss _pipeBoss;
    protected PipeBossState _nextState;
    protected virtual void Awake()
    {
        if(!transform.root.TryGetComponent<PipeBoss>(out _pipeBoss))
        {
            Debug.LogError("이거 어디갔어");
        }
        SetNextState();
    }

    protected virtual void SetNextState()
    {
        _nextState = _pipeBoss.IdleState;
    }

    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void ExitState();
}
