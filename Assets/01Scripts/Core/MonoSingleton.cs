using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
/*                if (_instance == null)
                {
                    Debug.LogError($"�̰� ���� Ŭ����");
                }*/
            }
            return _instance;
        }
    }

/*    private void OnDisable()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }*/
}
