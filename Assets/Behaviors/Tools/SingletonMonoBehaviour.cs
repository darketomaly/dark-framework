using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour : MonoBehaviour
{
    private static MonoBehaviour Instance;

    private void Start()
    {
        if (Instance)
        {
            if (Instance != this)
            {
                Debug.LogError($"<color=olive>Destroying {name} because singleton already exists</color>");
                Destroy(this);
            }
        }
        else
        {
            Instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
    }
}
