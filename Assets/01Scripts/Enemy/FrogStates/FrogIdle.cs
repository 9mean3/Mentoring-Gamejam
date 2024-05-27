using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogIdle : EnemyState
{


    public override void EnterState()
    {
        base.EnterState();
        _enemy.StopImmediately();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
