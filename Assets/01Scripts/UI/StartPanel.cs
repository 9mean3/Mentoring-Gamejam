using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameModeTxt;

    private void Awake()
    {
        SetText();
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
