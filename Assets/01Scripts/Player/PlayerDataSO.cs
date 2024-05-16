using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    Normal,
    Pipe,
    Boss,
    EnumSize,
}

[CreateAssetMenu(menuName ="SO/PlayerDataSO")]
public class PlayerDataSO : ScriptableObject
{
    public GameMode GameMode;
    public bool IsClearPipeBoss;
}
