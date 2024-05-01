using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBossTargetAttackState : PipeBossDecidedPostionState
{
    [SerializeField] private float _spawnTerm;

    private bool _isTargeting;

    public override void EnterState()
    {
        base.EnterState();

        _isTargeting = true;
        StartCoroutine(PipeSpawn());
    }

    private IEnumerator PipeSpawn()
    {
        foreach (var trm in _pipeTransforms)
        {
            SinglePipe obj = (SinglePipe)PoolManager.Instance.Pop("SinglePipe");
            _pipeList.Add(obj);
            obj.transform.position = trm.position;
            obj.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));

            Sequence seq = DOTween.Sequence();
            seq.Append(obj.transform.DOMoveX(trm.position.x - 3, _prepareTime).SetEase(Ease.OutBack));
            seq.Append(obj.transform.DOLocalMove(obj.transform.up, _attackingTime).SetEase(Ease.InBack)).OnComplete(() => { _isTargeting = false; });

            yield return new WaitForSeconds(_spawnTerm);
        }
    }

    public override void UpdateState()
    {
        if (_isTargeting)
        {
            foreach (var pipe in _pipeList)
            {
                Vector2 dir = GameManager.Instance.Player.transform.position - pipe.transform.position;
                pipe.transform.up = dir;
            }
        }
    }
    public override void ExitState()
    {
        base.ExitState();
    }
}
