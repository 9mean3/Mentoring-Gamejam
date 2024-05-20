using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;

public class PlatformBird : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    public PlayerInput PlayerInput { get { return _playerInput; } }
    [SerializeField] private float _moveSpeed;
    public float MoveSpeed { get { return _moveSpeed; } }
    [SerializeField] private float _jumpPower;
    public float JumpPower { get { return _jumpPower; } }

    [Header("그라웅드 체커")]
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _groundCheckDistance;

    public Rigidbody2D RigidbodyCompo { get; private set; }
    private SpriteRenderer _spriteRenderer;
    private PlayerStateMachine _stateMachine;

    private void Awake()
    {
        RigidbodyCompo = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _stateMachine = new PlayerStateMachine();

        foreach (PlayerStateEnum stateEnum in Enum.GetValues(typeof(PlayerStateEnum)))
        {
            string typeName = $"Player{stateEnum.ToString()}State";
            Type type = Type.GetType(typeName);
            if (type == null) Debug.Log("아 Shit");
            PlayerState stateInstance = Activator.CreateInstance(type, this, _stateMachine) as PlayerState;
            if (stateInstance == null) Debug.Log("Ah 쓋");
            _stateMachine.AddState(stateEnum, stateInstance);
        }
        _stateMachine.Initialize(PlayerStateEnum.Idle);
    }

    private void Update()
    {
        _stateMachine.CurrentState.UpdateState();
    }

    public void SetVelocity(float x, float y)
    {
        Vector2 vel = new Vector2(x, y);
        RigidbodyCompo.velocity = vel;
    }

    public bool IsGroundDetected() =>
    Physics2D.Raycast(_groundChecker.position, Vector2.down,
                        _groundCheckDistance, _whatIsGround);

    public void StopImmediately(bool withY = false)
    {
        if (withY)
        {
            RigidbodyCompo.velocity = new Vector2(0, RigidbodyCompo.velocity.y);
        }
        else
        {
            RigidbodyCompo.velocity = Vector2.zero;
        }
    }

    private void SpriteFlipX(float dir)
    {
        _spriteRenderer.flipX = dir > 0 ? false : true;
    }


}