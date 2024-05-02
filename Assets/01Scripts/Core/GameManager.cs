using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public FlappyBird Player { get; private set; }
    public float VerticalSpeed;
    public int BossSpawnScore;
    [SerializeField] private PipeBoss _boss;

    public int CurrentScore { get; private set; }
    


    public bool IsBoss = false;
    private bool _isBossSpawned = false;
    private bool _isBossState = false;


    private void Awake()
    {
        Player = FindObjectOfType<FlappyBird>();
    }

    public void AddScore(int score = 1)
    {
        CurrentScore += score;

        if (CurrentScore >= BossSpawnScore && !_isBossState)
        {
            _isBossState = true;
            UIManager.Instance.ChangeEnum(FBUIEnum.Boss);
        }
        if (CurrentScore >= BossSpawnScore + 2 && !_isBossSpawned)
        {
            _isBossSpawned = true;
            Instantiate(_boss, new Vector3(0, 0, 0), Quaternion.identity); // 꼭 수정해라 그렇지 않으면 너는 죽는다.
        }
    }
}
