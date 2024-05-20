using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    public float InputX { get; private set; }

    public event Action Jump;

    private void Awake()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()))
        {
            Jump?.Invoke();
        }

        InputX = Input.GetAxisRaw("Horizontal");
    }

    private void DebugJump()
    {
        Debug.Log("Jump");
    }
}
