using Oculus.Interaction;
using UnityEngine;

namespace DarkFramework
{
    public class DisplayCamera : MonoBehaviour
    {
        public Canvas m_Canvas;
        public FPSPlayer m_FpsPlayer;
    
        public Transform m_Transform;

        private void Start()
        {
            m_Canvas.gameObject.SetActive(true);
        }

        private void Update()
        {
            m_Transform.position = m_FpsPlayer.m_CenterEyeAnchor.position;
        }

        void FixedUpdate()
        {
            m_Transform.rotation = Quaternion.Lerp(m_Transform.rotation, m_FpsPlayer.m_CenterEyeAnchor.rotation, 5.0f * Time.deltaTime);
        }
    }
}