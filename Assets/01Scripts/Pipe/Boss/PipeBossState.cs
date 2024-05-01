using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PipeBossState : MonoBehaviour
{
    protected List<SinglePipe> _pipeList = new List<SinglePipe>();

    protected PipeBoss _pipeBoss;
    protected PipeBossState _nextState;
    protected virtual void Start()
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

    public virtual void EnterState()
    {
        _pipeList.Clear();
    }

    public abstract void UpdateState();

    public virtual void ExitState()
    {
        Debug.Log(DOTween.KillAll());

        foreach (var pipe in _pipeList)
        {
            PoolManager.Instance.Push(pipe);
        }
    }
}
