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
        foreach (var trm in _pipeTransforms)
        {
            SinglePipe obj = (SinglePipe)PoolManager.Instance.Pop("SinglePipe");
            _pipeList.Add(obj);
            obj.transform.position = trm.position;

            _targetingPipe[obj] = true;

            Sequence seq = DOTween.Sequence();
            seq.Append(obj.transform.DOMoveX(trm.position.x - 4, _prepareTime).SetEase(Ease.OutBack));
            seq.AppendCallback(() => { _targetingPipe[obj] = false; Debug.Log(_playerPos + (_playerPos - obj.transform.position)); });
            seq.Append(obj.transform.DOMove(_playerPos + (_playerPos - obj.transform.position), _attackingTime).SetEase(Ease.InBack));

            yield return new WaitForSeconds(_spawnTerm);
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
