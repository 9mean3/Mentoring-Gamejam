using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeObstacle : MonoBehaviour
{
    public float _verticalSpeed;

    private void Update()
    {
        transform.Translate(Vector2.left * _verticalSpeed * Time.deltaTime);
    }
}
