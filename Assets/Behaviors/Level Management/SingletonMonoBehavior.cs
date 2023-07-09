using UnityEngine;

namespace DarkFramework
{
    public abstract class SingletonMonoBehaviorBase : MonoBehaviour { }

    public abstract class SingletonMonoBehavior<T> : SingletonMonoBehaviorBase where T : SingletonMonoBehavior<T>, new()
    {
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
}