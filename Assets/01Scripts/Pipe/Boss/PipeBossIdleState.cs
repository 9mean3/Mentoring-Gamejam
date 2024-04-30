using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBossIdleState : PipeBossState
{
    [SerializeField] private List<float> _idleTime = new List<float>();
    float _curTime;
    public override void EnterState()
    {
        Debug.Log("Idle");
        _curTime = 0;
    }

    public override void UpdateState()
    {
        _curTime += Time.deltaTime;
        if (_curTime >= _idleTime[(int)_pipeBoss.CurrentBossMode])
        {
            int r;
            if (_pipeBoss.IsRandomPattern)
            {
                r = Random.Range(0, _pipeBoss.States.Count);
            }
            else
            {
                r = _pipeBoss.CurrentPatternIndex++;
                if(r >= _pipeBoss.States.Count)
                {
                    r = 0;
                }
            }

            _pipeBoss.ChangeState(_pipeBoss.States[r]);
        }
    }

    public override void ExitState()
    {

    }
}
