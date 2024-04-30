using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PipeBossVerticalAttackTogetherState : PipeBossVerticalAttackState
{
    private bool _isAttack;
    private float _currentTime;

    [Header("Dotween")]
    [SerializeField] private float _duration;

    public override void EnterState()
    {
        _isAttack = false;
        _currentTime = 0;

        foreach (var trm in _pipeTransforms)
        {
            SinglePipe obj = (SinglePipe)PoolManager.Instance.Pop("SinglePipe");
            _pipes.Add(obj);
            obj.transform.position = trm.position;
            obj.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));

            obj.transform.DOMoveX(trm.position.x - 3, _duration).SetEase(Ease.OutBack);
        }
    }

    public override void UpdateState()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime >= _prepareTime && !_isAttack)
        {
            _isAttack = true;
            foreach (var pipe in _pipes)
            {
                Debug.Log("aPPP");
                pipe.transform.DOMoveX(-12, _duration / 2).SetEase(Ease.InBack);
            }
        }
        
        if(_currentTime >= _prepareTime + _attackingTime - _duration)
        {
            foreach (var pipe in _pipes)
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
        foreach (var pipe in _pipes)
        {
            PoolManager.Instance.Push(pipe);
        }
    }
}
