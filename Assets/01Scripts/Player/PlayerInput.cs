using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    public event Action Jump;
    public event Action<float> MoveX;

    private void Awake()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()))
        {
            Jump?.Invoke();
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        MoveX.Invoke(moveX);

    }

    private void DebugJump()
    {
        Debug.Log("Jump");
    }

    private void DebugMoveX(float move)
    {
        Debug.Log(move);
    }
}
