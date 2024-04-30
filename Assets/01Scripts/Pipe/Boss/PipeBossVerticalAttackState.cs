using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBossVerticalAttackState : PipeBossState
{
    [SerializeField] protected Transform[] _pipeTransforms;
    [SerializeField] protected float _prepareTime;
    [SerializeField] protected float _attackingTime;
    protected List<SinglePipe> _pipes = new List<SinglePipe>();

    public override void EnterState()
    {
    }

    public override void UpdateState()
    {
    }

    public override void ExitState()
    {
        foreach (var pipe in _pipes)
        {
            PoolManager.Instance.Push(pipe);
        }
    }
}
