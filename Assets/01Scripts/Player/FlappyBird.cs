using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlappyBird : BirdBase
{
    protected override void Awake()
    {
        base.Awake();
        OnDie += DieEvent;
    }

    private void DieEvent()
    {
        _rb.freezeRotation = false;
        _rb.constraints = RigidbodyConstraints2D.None;
        _rb.AddForce(new Vector2(-1, 1) * 500);
    }
}
