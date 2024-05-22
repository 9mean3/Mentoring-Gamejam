using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    public bool UseMouseButtonJump;

    public float InputX { get; private set; }

    public event Action Jump;

    public event Action BasicAttack;

    private void Awake()
    {

    }

    private void Update()
    {
        if (UseMouseButtonJump)
        {
            if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()))
            {
                Jump?.Invoke();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump?.Invoke();
            }

            if (Input.GetMouseButtonDown(0))
            {
                BasicAttack?.Invoke();
            }
        }

        InputX = Input.GetAxisRaw("Horizontal");
    }

    private void DebugJump()
    {
        Debug.Log("Jump");
    }
}
