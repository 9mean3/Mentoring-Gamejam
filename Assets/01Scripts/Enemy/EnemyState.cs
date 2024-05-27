using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public void Initialize(Enemy enemy, EnemyStateMachine enemyStateMachine, Rigidbody2D rigidbody)
    {
        _enemy = enemy;
        _enemyStateMachine = enemyStateMachine;
        _rigidbody = rigidbody;
    }

    protected Enemy _enemy;
    protected EnemyStateMachine _enemyStateMachine;
    protected Rigidbody2D _rigidbody;

    //[SerializeField] protected List<Transition>

    public virtual void EnterState()
    {

    }

    public virtual void UpdateState()
    {

    }

    public virtual void ExitState()
    {

    }
}
