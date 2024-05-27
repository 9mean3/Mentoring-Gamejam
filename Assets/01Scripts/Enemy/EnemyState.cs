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

    public virtual void EnterState()
    {
        �ñ帥���۵��ǹݴ������ٶ󺸴����۵��Ǥ����������ΰ��������ġ�����ΉѾ�ΰ���¥�δ뺻�ټ����������ؾ��������γ��̰��ӿ������ڸ������������ΰ������ص�����������س����ٶ󺸰Ƿ��۵������ϴ�������¥������!switch���Ǵ¼۱׹ۿ������ߴ¤�����Ʈ���������ſ���ʴ�ì�ܾ���ǳ�̸�
    }

    public virtual void UpdateState()
    {

    }

    public virtual void ExitState()
    {

    }
}
