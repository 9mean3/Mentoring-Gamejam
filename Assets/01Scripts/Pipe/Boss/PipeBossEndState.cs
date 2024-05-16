using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBossEndState : PipeBossState
{
    public override void EnterState()
    {
        base.EnterState();

        SinglePipe pipe = (SinglePipe)PoolManager.Instance.Pop("SinglePipe");
        pipe.transform.position = new Vector2(10f, 0);
        pipe.transform.localScale = new Vector2(6f, 6f);
        _pipeList.Add(pipe);

        StartCoroutine(SpawnPipe());
    }

    private IEnumerator SpawnPipe()
    {
        SinglePipe pipe = _pipeList[0];
        pipe.transform.DOMoveX(4f, 4f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(7f);
        GameManager.Instance.Player.GetComponent<CapsuleCollider2D>().enabled = false;
        pipe.transform.DOMoveX(-2f, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.5f);
        _pipeBoss.ChangeState(_nextState);
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        base.ExitState();
        FlappyUIManager.Instance.GameEnd();
    }
}
