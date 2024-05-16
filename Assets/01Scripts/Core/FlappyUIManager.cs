using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyUIManager : MonoSingleton<FlappyUIManager>
{
    [SerializeField] private Image _blackImage;

    private FBUIEnum _currentEnum;
    public FBUIEnum CurrentEnum { get { return _currentEnum; } }
    public event Action<FBUIEnum> OnChangeState;

    [SerializeField] private Canvas _flappyBirdCanvas;
    public Canvas CurrentCanvas { get; private set; }

    private void Start()
    {
        _blackImage.enabled = false;
        CurrentCanvas = _flappyBirdCanvas;
        ChangeEnum(FBUIEnum.Start);
    }

    public void ChangeEnum(FBUIEnum nextEnum)
    {
        _currentEnum = nextEnum;
        OnChangeState.Invoke(nextEnum);
    }


    public void GameEnd()
    {
        SoundManager.Instance.StopBGM();
        GameManager.Instance.PlayerData.IsClearPipeBoss = true;
        CurrentCanvas.gameObject.SetActive(false);
        _blackImage.enabled = true;
        SceneManagement.Instance.LoadScene("FlappyPlatformScene");
    }
}
