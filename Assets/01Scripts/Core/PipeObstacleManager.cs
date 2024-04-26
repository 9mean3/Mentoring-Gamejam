using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PipeObstacleManager : MonoSingleton<PipeObstacleManager>
{
    public bool Spawnable { get; private set; } = false;
    [SerializeField] private GameObject _pipeObstacle;
    [SerializeField] private Transform _spawnPos;
    [SerializeField] private float _spawnYRange;
    [SerializeField] private float _spawnTerm;

    private Stack<GameObject> _pipeObstacleStack = new Stack<GameObject>();

    private void Awake()
    {
        UIManager.Instance.OnChangeState += OnUIChanged;

        for (int i = 0; i < 5; i++)
        {
            GameObject pipe = Instantiate(_pipeObstacle, _spawnPos);
            _pipeObstacleStack.Push(pipe);
            pipe.SetActive(false);
        }
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
        if (_pipeObstacleStack.Count > 0)
        {
            GameObject pipe = _pipeObstacleStack.Pop();
            pipe.transform.localPosition = new Vector2(0, Random.Range(-_spawnYRange, _spawnYRange));
            pipe.SetActive(true);
        }
        else
        {
            GameObject pipe = Instantiate(_pipeObstacle, _spawnPos);
            pipe.transform.localPosition = new Vector2(0, Random.Range(-_spawnYRange, _spawnYRange));
        }
    }

    public void PushPipe(GameObject pipe)
    {
        _pipeObstacleStack.Push(pipe);
        pipe.SetActive(false);
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
