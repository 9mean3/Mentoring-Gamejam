using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class Enemy : MonoBehaviour
{
    [Header("움직임 값들")]
    [SerializeField] private float _moveSpeed;
    public float MoveSpeed { get { return _moveSpeed; } }
    [SerializeField] private float _jumpPower;
    public float JumpPower { get { return _jumpPower; } }

    public int FacingDir { get; private set; }
    public Rigidbody2D RigidbodyCompo { get; private set; }
    private EnemyStateMachine _stateMachine;
    private SpriteRenderer _spriteRenderer;


    private void Awake()
    {
        RigidbodyCompo = GetComponent<Rigidbody2D>();
        _stateMachine = new EnemyStateMachine();
        _spriteRenderer = transform.Find("Visual").GetComponent<SpriteRenderer>();

        Transform startState = null;
        foreach (Transform stateTrm in transform.Find("States"))
        {
            EnemyState newState = stateTrm.GetComponent<EnemyState>();
            _stateMachine.AddState(stateTrm, newState);
            if (startState == null) startState = stateTrm;
        }

        _stateMachine.Initialize(startState);
    }

    public void SetVelocity(float x, float y)
    {
        Vector2 vel = new Vector2(x, y);
        RigidbodyCompo.velocity = vel;

        FlipController(x);
    }

    public virtual void Flip()
    {
        FacingDir = FacingDir * -1;
        transform.Rotate(0, 180f, 0);
    }

    public virtual void FlipController(float x)
    {
        bool gotoRight = x > 0 && FacingDir < 0;
        bool gotoLeft = x < 0 && FacingDir > 0;

        if (gotoRight || gotoLeft)
        {
            Flip();
        }
    }
}
