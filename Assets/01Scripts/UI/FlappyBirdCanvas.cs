using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdCanvas : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [Space]
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _endPanel;
    private void Awake()
    {
        UIManager.Instance.OnChangeState += SetUI;
    }

    private void SetUI(FBUIEnum obj)
    {
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
            case FBUIEnum.End:
                {
                    _startPanel.SetActive(false);
                    _endPanel.SetActive(true);
                    _playerInput.Jump += ReStartGame;
                }
                break;
            default:
                break;
        }
    }

    private void StartGame()
    {
        UIManager.Instance.ChangeEnum(FBUIEnum.Game);
    }

    private void ReStartGame()
    {
        //UIManager.Instance.ChangeEnum(FBUIEnum.Start);
        SceneManagement.Instance.LoadScene("FlappyBirdScene");
    }

    private void OnDisable()
    {
        UIManager.Instance.OnChangeState -= SetUI;
        _playerInput.Jump -= ReStartGame;
        _playerInput.Jump -= StartGame;
    }
}
