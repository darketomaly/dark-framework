using UnityEngine;

namespace DarkFramework
{
    /// <summary>
    /// Contains the VR rig and player controller
    /// </summary>
    public class FPSPlayer : SingletonMonoBehavior<FPSPlayer>
    {
        public Transform m_CenterEyeAnchor;
        
        private void Start()
        {
            if (m_Initialized)
            {
                //transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        public void Teleport(Vector3 floorPosition)
        {
            //transform.GetChild(0).position = floorPosition + Vector3.up;
        }
    }
}