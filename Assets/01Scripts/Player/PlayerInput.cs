using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    public event Action Jump;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()))
        {
            Jump?.Invoke();
        }
    }
}
