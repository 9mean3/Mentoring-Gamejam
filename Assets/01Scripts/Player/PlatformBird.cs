using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBird : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private BoxCollider2D _groundChecker;

    private bool _isGround;
    private int _curX;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _groundChecker = transform.Find("GroundChecker").GetComponent<BoxCollider2D>();

        _playerInput.MoveX += MoveXEvent;
        _playerInput.Jump += JumpEvent;
    }

    private void Update()
    {
        //Debug.Log(_rigidbody.velocity);
        if (_groundChecker.IsTouchingLayers(LayerMask.NameToLayer("Ground")))
        {
            _isGround = true;
        }
        else
        {
            _isGround = false;
        }
    }

    private void MoveXEvent(float input)
    {
        float vel = input * _moveSpeed;
        _rigidbody.velocity = new Vector2(vel, _rigidbody.velocity.y);

        if (Mathf.Abs(_rigidbody.velocity.x) > 0.1f)
        {
            SpriteFlipX(_rigidbody.velocity.x);
        }
    }

    private void JumpEvent()
    {
        if (_isGround)
            _rigidbody.velocity += Vector2.up * _jumpPower;
    }

    private void SpriteFlipX(float dir)
    {
        _spriteRenderer.flipX = dir > 0 ? false : true;
    }
}
