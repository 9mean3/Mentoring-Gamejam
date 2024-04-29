using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PipeObstacleManager : MonoSingleton<PipeObstacleManager>
{
    public bool Spawnable { get; private set; } = false;
    [SerializeField] private float _spawnYRange;
    [SerializeField] private float _spawnTerm;

    private void Awake()
    {
        UIManager.Instance.OnChangeState += OnUIChanged;
    }



    private void OnUIChanged(FBUIEnum nextEnum)
    {
        switch (nextEnum)
        {
            case FBUIEnum.Start:
                {
                    Spawnable = false;
                    StopAllCoroutines();
                }
                break;
            case FBUIEnum.Game:
                {
                    Spawnable = true;
                    StartCoroutine(SpawningPipeObstacle());
                }
                break;
            case FBUIEnum.End:
                {
                    Spawnable = false;
                    StopAllCoroutines();
                }
                break;
            default:
                break;
        }
    }

    private void SpawnPipeObstacle()
    {
        PoolableMono pipe = PoolManager.Instance.Pop("PipeObstacle");
        pipe.transform.localPosition = new Vector2(20, Random.Range(-_spawnYRange, _spawnYRange));
    }

    public void PushPipe(PipeObstacle pipe)
    {
        PoolManager.Instance.Push(pipe);
    }

    private IEnumerator SpawningPipeObstacle()
    {
        while (Spawnable)
        {
            SpawnPipeObstacle();
            yield return new WaitForSeconds(_spawnTerm);
        }
    }
}
