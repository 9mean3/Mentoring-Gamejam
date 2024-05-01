using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBossDecidedPostionState : PipeBossState
{
    [SerializeField] protected Transform[] _pipeTransforms;
    [SerializeField] protected float _prepareTime;
    [SerializeField] protected float _attackingTime;

    public override void EnterState()
    {
    }

    public override void UpdateState()
    {
    }
}
