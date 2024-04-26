using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FBUIEnum
{
    Start,
    Game,
    End,
}

public class UIManager : MonoSingleton<UIManager>
{
    private FBUIEnum _currentEnum;
    public FBUIEnum CurrentEnum { get { return _currentEnum; } }
    public event Action<FBUIEnum> OnChangeState;

    private void Start()
    {
        ChangeEnum(FBUIEnum.Start);
    }

    public void ChangeEnum(FBUIEnum nextEnum)
    {
        _currentEnum = nextEnum;
        OnChangeState.Invoke(nextEnum);
    }
}
