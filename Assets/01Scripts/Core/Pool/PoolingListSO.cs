using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct PoolingPair
{
    public PoolableMono Prefab;
    public int Count;
}

[CreateAssetMenu(menuName = "SO/PoolingListSO")]
public class PoolingListSO : ScriptableObject
{
    public List<PoolingPair> List;
}
