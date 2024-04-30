using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeObstacle : PoolableMono
{
    private bool isScored = false;

    public override void Reset()
    {
        base.Reset();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * GameManager.Instance.VerticalSpeed * Time.deltaTime);

        if(transform.position.x < -20)
        {
            PipeObstacleManager.Instance.PushPipe(this);
        }

        if(transform.position.x < GameManager.Instance.Player.transform.position.x && !isScored)
        {
            isScored = true;
            GameManager.Instance.AddScore();
        }
    }
}
