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
        시긷른래퍼들의반대편을바라보던래퍼들의ㅇ배포백프로개뻥개빨어마치템프로됏어보인각본짜인대본텐션을업으로해야지제댛로난이게임에서아코르벳내랩은전부감으로해돈벌어먹지못해나를바라보건래퍼들은말하더눅ㄴ진짜개좆돼!switch돈되는송그밖에내가추는ㅌ위스트딥해진기운탓에너는챙겨야해풍미를
    }

    public virtual void UpdateState()
    {

    }

    public virtual void ExitState()
    {

    }
}
