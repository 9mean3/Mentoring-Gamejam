using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public FlappyBird Player { get; private set; }
    public float VerticalSpeed;
    public int BossSpawnScore;

    [SerializeField] private PlayerDataSO _playerData;
    [SerializeField] private PipeBoss _boss;

    public PlayerDataSO PlayerData { get { return _playerData; } }
    public int CurrentScore { get; private set; }

    private bool _isBossSpawned = false;


    private void Awake()
    {
        Player = FindObjectOfType<FlappyBird>();

        UIManager.Instance.OnChangeState += SpawnBoss;
    }

    public void ChangeGameMode(GameMode newGameMode)
    {
        PlayerData.GameMode = newGameMode;
        Debug.Log(PlayerData.GameMode);
    }

    public void AddScore(int score = 1)
    {
        CurrentScore += score;
        GameMode gameMode = PlayerData.GameMode;

        switch (gameMode)
        {
            case GameMode.Normal:
                {
                    if (CurrentScore >= BossSpawnScore + 2 && !_isBossSpawned)
                    {
                        _isBossSpawned = true;
                        UIManager.Instance.ChangeEnum(FBUIEnum.Boss);
                    }
                }
                break;
            default:
                break;
        }
    }

    private void SpawnBoss(FBUIEnum uiState)
    {
        if (uiState == FBUIEnum.Boss)
        {
            StartCoroutine(SpawnBossCor(3));
        }
    }

    private IEnumerator SpawnBossCor(float spawnTime)
    {
        yield return new WaitForSeconds(spawnTime);
        Instantiate(_boss, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
