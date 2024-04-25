using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBase : MonoBehaviour
{
    [SerializeField] protected float _jumpPower;
    protected Rigidbody2D _rb;
    protected PlayerInput _playerInput;

    public event Action OnDie;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();

        _playerInput.Jump += Jump;
        OnDie += Die;
    }

    private void Update()
    { 
        transform.localEulerAngles = Vector3.Slerp(transform.localEulerAngles, new Vector3(0, 0, _rb.velocity.y), 20);
    }

    protected virtual void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        _rb.velocity += Vector2.up * _jumpPower;
    }

    protected virtual void Die()
    {
        _playerInput.Jump -= Jump;
        GameManager.Instance.VerticalSpeed = 0;
    }

    protected virtual void OnDisable()
    {
        _playerInput.Jump -= Jump;
        OnDie -= Die;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Obstacle"))
        {
            OnDie.Invoke();
        }
    }
}
