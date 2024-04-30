using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public FlappyBird Player { get; private set; }
    public float VerticalSpeed;
    public int BossSpawnScore;
    public int CurrentScore { get; private set; }

    private void Awake()
    {
        Player = FindObjectOfType<FlappyBird>();
    }

    public void AddScore(int score = 1)
    {
        CurrentScore += score;

        if(CurrentScore >= BossSpawnScore)
        {
            UIManager.Instance.ChangeEnum(FBUIEnum.Boss);
        }
    }
}
