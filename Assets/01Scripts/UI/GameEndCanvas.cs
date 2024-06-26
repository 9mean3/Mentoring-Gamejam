using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _congTxt;
    [SerializeField] TextMeshProUGUI _descTxt;
    [SerializeField] TextMeshProUGUI _exitTxt;

    private void OnEnable()
    {

    }

    private void Awake()
    {
        _congTxt.color = new Color(1, 1, 1, 0);
        _descTxt.color = new Color(1, 1, 1, 0);
        _exitTxt.color = new Color(1, 1, 1, 0);
        StartCoroutine(WaitEnd());
    }

    private IEnumerator WaitEnd()
    {
        yield return new WaitForSeconds(2f);

        Sequence seq = DOTween.Sequence();
        seq.Append(_congTxt.DOFade(1, 2f));
        seq.Append(_descTxt.DOFade(1, 1.5f));
        seq.Append(_exitTxt.DOFade(1, 1.5f));

        SoundManager.Instance.PlayBGM("GameEnd");
    }
}
