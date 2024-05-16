using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameModeTxt;
    [SerializeField] private Button _flappyPlatformBtn;

    private void Awake()
    {
        SetText();

        if (GameManager.Instance.PlayerData.IsClearPipeBoss)
        {
            _flappyPlatformBtn.interactable = true;
        }
        else
        {
            _flappyPlatformBtn.interactable = false;
        }
    }

    public void ChangeGameMode()
    {
        GameMode nextGameMode = ++GameManager.Instance.PlayerData.GameMode;
        if (nextGameMode == GameMode.EnumSize)
        {
            GameManager.Instance.ChangeGameMode(0);
        }
        else
        {
            GameManager.Instance.ChangeGameMode(nextGameMode);
        }
        SetText();
    }

    private void SetText()
    {
        GameMode nextGameMode = GameManager.Instance.PlayerData.GameMode;
        _gameModeTxt.text = nextGameMode.ToString();
    }
}
