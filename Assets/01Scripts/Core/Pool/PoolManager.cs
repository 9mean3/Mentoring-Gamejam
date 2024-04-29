using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField] private PoolingListSO _poolingListSO;
    [SerializeField] private Transform _poolParent;
    private Dictionary<string, Pool<PoolableMono>> _pools = new Dictionary<string, Pool<PoolableMono>>();

    private void Awake()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        if (_poolingListSO == null)
            return;
        foreach (PoolingPair item in _poolingListSO.List)
        {
            PoolableMono prefab = item.Prefab;
            int count = item.Count;

            Pool<PoolableMono> pool = new Pool<PoolableMono>(prefab, _poolParent, count);
            _pools[prefab.gameObject.name] = pool;
        }
    }

    public void CreatePool(PoolableMono prefab, int count)
    {
        Pool<PoolableMono> pool = new Pool<PoolableMono>(prefab, _poolParent, count);
        _pools[prefab.gameObject.name] = pool;
    }

    public PoolableMono Pop(string prefabName)
    {
        PoolableMono obj = _pools[prefabName].Pop();
        obj.Reset();
        return obj;
    }

    public void Push(PoolableMono prefab)
    {
        _pools[prefab.gameObject.name].Push(prefab);
    }
}
