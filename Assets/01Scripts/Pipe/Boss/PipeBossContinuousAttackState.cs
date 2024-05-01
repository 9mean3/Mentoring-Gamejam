using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBossContinuousAttackState : PipeBossDecidedPostionState
{
    [SerializeField] float _nextPipeMoveTime;
    public override void EnterState()
    {
        base.EnterState();

        StartCoroutine(SpawnPipes());
    }

    private IEnumerator SpawnPipes()
    {
        int i = 1;
        foreach (var trm in _pipeTransforms)
        {
            SinglePipe pipe = (SinglePipe)PoolManager.Instance.Pop("SinglePipe");
            _pipeList.Add(pipe);
            pipe.transform.position = trm.position;
            pipe.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));

            Sequence seq = DOTween.Sequence();
            seq.Append(pipe.transform.DOMoveX(trm.position.x - 3, _prepareTime).SetEase(Ease.OutBack));
            seq.Append(pipe.transform.DOMoveX(-40, _attackingTime).SetEase(Ease.InBack));

            if (i >= _pipeTransforms.Length)
            {
                seq.OnComplete(() => { _pipeBoss.ChangeState(_nextState); });
                break;  
            }
            yield return new WaitForSeconds(_nextPipeMoveTime);
            i++;
        }
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
