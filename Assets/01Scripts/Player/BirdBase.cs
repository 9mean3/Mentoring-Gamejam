using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdBase : MonoBehaviour
{
    [SerializeField] protected float _jumpPower;
    protected Rigidbody2D _rb;
    protected PlayerInput _playerInput;

    protected bool _idling = true;

    public event Action OnDie;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();

        UIManager.Instance.OnChangeState += OnUIChanged;
    }

    private void Update()
    {
        if (_idling)
        {
            transform.position = new Vector2(0, Mathf.Sin(3f * Time.time) * 0.5f);
        }
        else
        {
            transform.localEulerAngles = Vector3.Slerp(transform.localEulerAngles, new Vector3(0, 0, _rb.velocity.y), 20);
        }
    }

    protected virtual void OnUIChanged(FBUIEnum nextEnum)
    {
        switch (nextEnum)
        {
            case FBUIEnum.Start:
                {
                    _idling = true;
                    _playerInput.Jump += Jump;
                    OnDie -= Die;
                }
                break;
            case FBUIEnum.Game:
                {
                    _idling = false;
                    _playerInput.Jump += Jump;
                    OnDie += Die;
                }
                break;
            case FBUIEnum.End:
                {
                    _playerInput.Jump -= Jump;
                    OnDie -= Die;
                }
                break;
            default:
                break;
        }
    }

    protected virtual void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        _rb.velocity += Vector2.up * _jumpPower;
    }

    protected virtual void Die()
    {
        GameManager.Instance.VerticalSpeed = 0;
        UIManager.Instance.ChangeEnum(FBUIEnum.End);
    }

    protected virtual void OnDisable()
    {
            //UIManager.Instance.OnChangeState -= OnUIChanged;
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
