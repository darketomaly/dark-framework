using UnityEngine;

namespace DarkFramework
{
    /// <summary>
    /// Contains the VR rig and player controller
    /// </summary>
    public class FPSPlayer : SingletonMonoBehavior<FPSPlayer>
    {
        public Transform m_CenterEyeAnchor;
        public Transform m_TrackerOffsets;

        private void OnEnable()
        {
            SceneLoadManager.Instance.OnSceneLoaded += OnSceneLoaded;
        }
        
        private void OnDisable()
        {
            SceneLoadManager.Instance.OnSceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(LeveLReference levelLoaded)
        {
            m_TrackerOffsets.rotation = Quaternion.identity;
        }

        private void Start()
        {
            if (m_Initialized)
            {

            }
        }

        public void Teleport(Vector3 floorPosition)
        {
            //transform.GetChild(0).position = floorPosition + Vector3.up;
        }
    }
}