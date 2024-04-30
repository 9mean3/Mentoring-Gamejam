using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeObstacle : PoolableMono
{
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
    }
}
