using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBossCrushBetweenState : PipeBossState
{
    [SerializeField] private Transform _spawnTransform;
    [SerializeField] private Transform _destroyTransform;

    [SerializeField] private float _pipeDistance;
    [SerializeField] private float _moveDuration;
    [SerializeField] private float _attackTime;

    [SerializeField] int _spawnCount;
    [SerializeField] float _nextPipeSpawnTime;
    public override void EnterState()
    {
        base.EnterState();

        StartCoroutine(SpawnPipes());
    }

    private IEnumerator SpawnPipes()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            SinglePipe leftPipe = (SinglePipe)PoolManager.Instance.Pop("SinglePipe");
            _pipeList.Add(leftPipe);
            leftPipe.transform.position = _spawnTransform.position;
            leftPipe.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -90));

            SinglePipe rightPipe = (SinglePipe)PoolManager.Instance.Pop("SinglePipe");
            _pipeList.Add(rightPipe);
            rightPipe.transform.position = _spawnTransform.position;
            rightPipe.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));

            Sequence seq = DOTween.Sequence();
            leftPipe.transform.DOMoveY(_destroyTransform.position.y, _moveDuration).SetEase(Ease.Linear);
            seq.Append(leftPipe.transform.DOMoveX(-_pipeDistance, _attackTime).SetEase(Ease.OutQuad));
            seq.Append(leftPipe.transform.DOMoveX(0, 0.2f));
            seq.SetLoops(-1);


            Sequence seqq = DOTween.Sequence();
            if (i >= _spawnCount - 1)
            {
                rightPipe.transform.DOMoveY(_destroyTransform.position.y, _moveDuration).SetEase(Ease.Linear).OnComplete(() => { _pipeBoss.ChangeState(_nextState); });
            }
            else
            {
                rightPipe.transform.DOMoveY(_destroyTransform.position.y, _moveDuration).SetEase(Ease.Linear);
            }
            seqq.Append(rightPipe.transform.DOMoveX(_pipeDistance, _attackTime).SetEase(Ease.OutQuad));
            seqq.Append(rightPipe.transform.DOMoveX(0, 0.2f));
            seqq.SetLoops(-1);

            yield return new WaitForSeconds(_nextPipeSpawnTime);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
    }
}
