using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonMonoBehaviorBase : MonoBehaviour { }

public abstract class SingletonMonoBehavior<T> : SingletonMonoBehaviorBase where T : SingletonMonoBehavior<T>, new()
{
    //private static T _instance = new T();

    //public static T Instance => _instance;

    public static T Instance;
    protected bool m_Initialized;

    private void Awake()
    {
        if (Instance)
        {
            if (Instance != this)
            {
                name += " (Bad clone)";
                Debug.Log($"<color=olive>Destroying {name} because singleton already exists</color>");
                Destroy(gameObject);
            }
        }
        else
        {
            m_Initialized = true;
            Instance = (T)this;
            name += " (Good clone)";
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
    }
}