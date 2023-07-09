using UnityEngine;

namespace DarkFramework
{
    /// <summary>
    /// Contains the VR rig and player controller
    /// </summary>
    public class FPSPlayer : MonoBehaviour
    {
        public static FPSPlayer Instance;
        
        public Transform m_CenterEyeAnchor;
        
        public bool m_Initialized;

        protected void Awake()
        {
            if (Instance)
            {
                if (Instance != this)
                {
                    name += " (Bad clone)";
                    Debug.LogError($"<color=olive>Destroying {name} because singleton already exists</color>");
                    Destroy(gameObject);
                }
            }
            else
            {
                m_Initialized = true;
                Instance = this;
                name += " (Good clone)";
                transform.parent = null;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Start()
        {
            if (m_Initialized)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}