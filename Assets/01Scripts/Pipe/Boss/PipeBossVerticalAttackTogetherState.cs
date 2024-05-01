using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PipeBossVerticalAttackTogetherState : PipeBossDecidedPostionState
{
    private bool _isAttacked;
    private bool _isArrived;
    private float _currentTime;

    [Header("Dotween")]
    [SerializeField] private float _duration;

    public override void EnterState()
    {
        base.EnterState();

        _isAttacked = false;
        _isArrived = false;
        _currentTime = 0;

        foreach (var trm in _pipeTransforms)
        {
            SinglePipe obj = (SinglePipe)PoolManager.Instance.Pop("SinglePipe");
            _pipeList.Add(obj);
            obj.transform.position = trm.position;
            obj.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));

            obj.transform.DOMoveX(trm.position.x - 3, _duration).SetEase(Ease.OutBack);
        }
    }

    public override void UpdateState()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime >= _prepareTime && !_isAttacked)
        {
            _isAttacked = true;
            foreach (var pipe in _pipeList)
            {
                pipe.transform.DOMoveX(-11, _duration / 2).SetEase(Ease.InBack);
            }
        }
        
        if(_currentTime >= _prepareTime + _attackingTime - _duration && !_isArrived)
        {
            _isArrived = true;
            foreach (var pipe in _pipeList)
            {
                pipe.transform.DOMoveX(-40, _duration);
            }
        }

        if (_currentTime >= _prepareTime + _attackingTime)
        {
            _pipeBoss.ChangeState(_nextState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
