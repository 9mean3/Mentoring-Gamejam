using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeObstacle : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector2.left * GameManager.Instance.VerticalSpeed * Time.deltaTime);
    }
}
