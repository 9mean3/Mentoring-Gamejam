using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBossTargetAttackState : PipeBossDecidedPostionState
{
    [SerializeField] private float _spawnTerm;

    private Dictionary<SinglePipe, bool> _targetingPipe = new Dictionary<SinglePipe, bool>();
    private Vector3 _playerPos;

    public override void EnterState()
    {
        base.EnterState();
        StartCoroutine(PipeSpawn());
    }

    private IEnumerator PipeSpawn()
    {
        int i = 0;
        foreach (var trm in _pipeTransforms)
        {
            SinglePipe obj = (SinglePipe)PoolManager.Instance.Pop("SinglePipe");
            _pipeList.Add(obj);
            obj.transform.position = trm.position;

            _targetingPipe[obj] = true;

            Sequence seq = DOTween.Sequence();
            seq.Append(obj.transform.DOMoveX(trm.position.x - 3, _prepareTime).SetEase(Ease.OutBack));
            seq.AppendCallback(() => { _targetingPipe[obj] = false; })
                .OnComplete(() =>
                {
                    if (i >= _pipeTransforms.Length)
                    {
                        Attack(obj, true);
                    }
                    else
                    {
                        Attack(obj);
                    }
                });
            i++;
            yield return new WaitForSeconds(_spawnTerm);
        }
    }

    private void Attack(SinglePipe pipe, bool isLast = false)
    {
        if (!isLast)
        {
            pipe.transform.DOMove(_playerPos + (_playerPos - pipe.transform.position).normalized * 40, _attackingTime)
                .SetEase(Ease.InBack);
        }
        else
        {
            pipe.transform.DOMove(_playerPos + (_playerPos - pipe.transform.position).normalized * 40, _attackingTime)
                .SetEase(Ease.InBack)
                .OnComplete(() => { _pipeBoss.ChangeState(_nextState); });
        }
    }

    public override void UpdateState()
    {
        _playerPos = GameManager.Instance.Player.transform.position;
        foreach (var pipe in _pipeList)
        {
            if (_targetingPipe[pipe])
            {
                Vector3 dir = _playerPos - pipe.transform.position;
                dir.Normalize();
                pipe.transform.up = dir;
            }
        }
    }
    public override void ExitState()
    {
        base.ExitState();
    }
}
