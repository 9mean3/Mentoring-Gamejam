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
        _spriteRenderer = transform.Find("Visual").GetComponent<SpriteRenderer>();

        _stateMachine = new PlayerStateMachine();

        foreach (PlayerStateEnum stateEnum in Enum.GetValues(typeof(PlayerStateEnum)))
        {
            string typeName = $"Player{stateEnum.ToString()}State";
            
            try
            {
                Type type = Type.GetType(typeName);
                PlayerState stateInstance = (PlayerState)Activator.CreateInstance(type, this, _stateMachine);
                _stateMachine.AddState(stateEnum, stateInstance);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                throw;
            }
        }
        _stateMachine.Initialize(PlayerStateEnum.Idle);
    }

    private void Update()
    {
        _stateMachine.CurrentState.UpdateState();
    }

    public void SetVelocity(float x, float y, bool doNotFilp = false)
    {
        Vector2 vel = new Vector2(x, y);
        RigidbodyCompo.velocity = vel;

        if (!doNotFilp && Mathf.Abs(x) > 0.05f)
        {
            SpriteFlipX(x); 
        }
    }

    public bool IsGroundDetected() =>
    Physics2D.Raycast(_groundChecker.position, Vector2.down,
                        _groundCheckDistance, _whatIsGround);

    public void StopImmediately(bool withY = false)
    {
        if (withY)
        {
            RigidbodyCompo.velocity = Vector2.zero;
        }
        else
        {
            RigidbodyCompo.velocity = new Vector2(0, RigidbodyCompo.velocity.y);
        }
    }

    private void SpriteFlipX(float dirX)
    {
        _spriteRenderer.flipX = dirX > 0 ? false : true;
    }


}