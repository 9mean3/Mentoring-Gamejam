using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBird : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;

    [Header("그라웅드 체커")]
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _groundCheckDistance;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private bool _isGround;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _playerInput.MoveX += MoveXEvent;
        _playerInput.Jump += JumpEvent;
    }

    private void OnDestroy()
    {
        _playerInput.MoveX -= MoveXEvent;
        _playerInput.Jump -= JumpEvent;
    }

    private void Update()
    {
        int groundLayerMask = 1 << LayerMask.NameToLayer("Ground");

        if (IsGroundDetected())
        {
            _isGround = true;
        }
        else
        {
            _isGround = false;
        }
    }

    private void SetVelocity(float x, float y)
    {
        Vector2 vel = new Vector2(x, y);
        _rigidbody.velocity = vel;
    }

    public bool IsGroundDetected() =>
    Physics2D.Raycast(_groundChecker.position, Vector2.down,
                        _groundCheckDistance, _whatIsGround);

    private void MoveXEvent(float input)
    {
        float vel = input * _moveSpeed;
        SetVelocity(vel, _rigidbody.velocity.y);

        if (Mathf.Abs(_rigidbody.velocity.x) > 0.1f)
        {
            SpriteFlipX(_rigidbody.velocity.x);
        }
    }

    private void JumpEvent()
    {
        if (_isGround)
            SetVelocity(_rigidbody.velocity.x, _jumpPower);
    }

    private void SpriteFlipX(float dir)
    {
        _spriteRenderer.flipX = dir > 0 ? false : true;
    }

    
}