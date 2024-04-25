using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdCanvas : MonoBehaviour
{
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
                _startPanel.SetActive(true);
                _endPanel.SetActive(false);
                break;
            case FBUIEnum.Game:
                _startPanel.SetActive(false);
                _endPanel.SetActive(false);
                break;
            case FBUIEnum.End:
                _startPanel.SetActive(true);
                _endPanel.SetActive(true);
                break;
            default:
                break;
        }
    }
}
