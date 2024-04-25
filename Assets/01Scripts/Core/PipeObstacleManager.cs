using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeObstacleManager : MonoSingleton<PipeObstacleManager>
{
    [SerializeField] private GameObject _pipeObstacle;
    [SerializeField] private Transform _spawnPos;
    [SerializeField] private float _spawnYRange;
    [SerializeField] private float _spawnTerm;

    private void Awake()
    {
        StartCoroutine(SpawningPipeObstacle());
    }

    private void SpawnPipeObstacle()
    {
        GameObject pipe = Instantiate(_pipeObstacle, _spawnPos);
        pipe.transform.localPosition = Vector2.up * Random.Range(-_spawnYRange, _spawnYRange);
    }

    private IEnumerator SpawningPipeObstacle()
    {
        while (true)
        {
            SpawnPipeObstacle();
            yield return new WaitForSeconds(_spawnTerm);
        }
    }
}
