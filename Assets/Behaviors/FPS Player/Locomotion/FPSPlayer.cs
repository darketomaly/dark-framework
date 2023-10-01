using Autohand;
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
        public AutoHandPlayer m_Player;

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

            if (levelLoaded is LeveLReference.Loading or LeveLReference.Splash)
            {
                m_Player.body.isKinematic = true;
                transform.position = Vector3.zero;
                m_Player.body.transform.position = Vector3.zero;
            }
        }

        private void Start()
        {
            if (m_Initialized)
            {

            }
        }

        public void Teleport(Vector3 floorPosition)
        {
            m_Player.body.isKinematic = true;
            transform.position = floorPosition + Vector3.up;
            m_Player.body.isKinematic = false;
        }
    }
}