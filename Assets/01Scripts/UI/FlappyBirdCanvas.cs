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
                    GameManager.Instance.IsBoss = true;
                }
                break;
            case FBUIEnum.End:
                {
                    _startPanel.SetActive(false);
                    _endPanel.SetActive(true);
                    _playerInput.Jump += ReStartGame;
                    GameManager.Instance.IsBoss = false;
                    DOTween.KillAll();
                }
                break;
            default:
                break;
        }
    }

    private void StartGame()
    {
        if (_isBoss)
            UIManager.Instance.ChangeEnum(FBUIEnum.Boss); /////////// 이거 꼭 바꿔라 그렇지 않으면 너는 죽는다
        else
            UIManager.Instance.ChangeEnum(FBUIEnum.Game);
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
