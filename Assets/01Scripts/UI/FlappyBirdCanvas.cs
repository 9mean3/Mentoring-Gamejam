using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlappyBirdCanvas : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [Space]
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private TextMeshProUGUI _scoreText;

    [Header("Test")]
    [SerializeField] private bool _isBoss;

    private void Awake()
    {
        UIManager.Instance.OnChangeState += SetUI;
    }

    private void Update()
    {
        _scoreText.text = GameManager.Instance.CurrentScore.ToString();
    }

    private void SetUI(FBUIEnum obj)
    {
        Debug.Log(obj.ToString());
        switch (obj)
        {
            case FBUIEnum.Start:
                {
                    _startPanel.SetActive(true);
                    _endPanel.SetActive(false);
                    _playerInput.Jump += StartGame;
                    _playerInput.Jump -= ReStartGame;
                }
                break;
            case FBUIEnum.Game:
                {
                    _startPanel.SetActive(false);
                    _endPanel.SetActive(false);
                    _playerInput.Jump -= StartGame;
                }
                break;
            case FBUIEnum.Boss:
                {
                    _startPanel.SetActive(false);
                    _endPanel.SetActive(false);
                    _playerInput.Jump -= StartGame;
                }
                break;
            case FBUIEnum.End:
                {
                    _startPanel.SetActive(false);
                    _endPanel.SetActive(true);
                    _playerInput.Jump += ReStartGame;
                    DOTween.KillAll();
                }
                break;
            default:
                break;
        }
    }

    private void StartGame()
    {
        Debug.Log("GameMode: " + GameManager.Instance.PlayerData.GameMode);
        switch (GameManager.Instance.PlayerData.GameMode)
        {
            case GameMode.Normal:
            case GameMode.Pipe:
                {
                    UIManager.Instance.ChangeEnum(FBUIEnum.Game);
                }
                break;
            case GameMode.Boss:
                {
                    UIManager.Instance.ChangeEnum(FBUIEnum.Boss);
                }
                break;
            default:
                break;
        }
    }

    private void ReStartGame()
    {
        SceneManagement.Instance.LoadScene("FlappyBirdScene");
    }

    private void OnDisable()
    {
        //UIManager.Instance.OnChangeState -= SetUI;
        _playerInput.Jump -= ReStartGame;
        _playerInput.Jump -= StartGame;
    }
}
