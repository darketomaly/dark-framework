using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour : MonoBehaviour
{
    public bool m_Initialized;
    
    private static MonoBehaviour Instance;

    private void Awake()
    {
        if (Instance)
        {
            if (Instance != this)
            {
                name += "(Bad clone)";
                Debug.LogError($"<color=olive>Destroying {name} because singleton already exists</color>");
                Destroy(this);
            }
        }
        else
        {
            m_Initialized = true;
            Instance = this;
            name += "(Good clone)";
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
    }
}
