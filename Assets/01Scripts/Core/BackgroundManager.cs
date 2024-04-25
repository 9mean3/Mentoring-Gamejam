using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoSingleton<BackgroundManager>
{
    public bool ScrollBackground = true;
    [SerializeField] private GameObject _background;
    private List<GameObject> _backgroundList = new List<GameObject>();

    private void Awake()
    {
        SetBackground(2);
    }

    public void SetBackground(int count)
    {
        if(_backgroundList != null)
        {
            _backgroundList.Clear();
        }

        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(_background, transform);
            go.transform.position = Vector2.zero;
            _backgroundList.Add(go);
        }

        for (int i = 1; i < count; i++)
        {
            _backgroundList[i].transform.position = new Vector2(18.8f * i, 0);
        }
    }

    private void Update()
    {
        if (!ScrollBackground)
            return;
        foreach (GameObject bg in _backgroundList)
        {
            bg.transform.Translate(Vector2.left * (GameManager.Instance.VerticalSpeed / 2) * Time.deltaTime);
            if(bg.transform.position.x < -18.3)
            {
                bg.transform.position = new Vector2(18.3f, 0);
            }
        }
    }
}
