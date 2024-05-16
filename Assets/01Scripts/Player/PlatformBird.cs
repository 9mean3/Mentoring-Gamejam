    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBird : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _playerInput.MoveX += MoveXEvent;
        _playerInput.Jump += JumpEvent;
    }

    private void Update()
    {
        Debug.Log(_rigidbody.velocity);
    }

    private void MoveXEvent(float input)
    {
        float vel = input * _moveSpeed;
        _rigidbody.velocity = new Vector2(vel, _rigidbody.velocity.y);
    }

    private void JumpEvent()
    {
        _rigidbody.velocity += Vector2.up * _jumpPower;
    }
}
