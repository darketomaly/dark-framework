using Oculus.Interaction;
using UnityEngine;

namespace DarkEngine
{
    public class DisplayCamera : MonoBehaviour
    {
        public Canvas m_Canvas;
    
        public Transform m_leftEyeAnchor;
        public Transform m_rightEyeAnchor;
        public Transform m_centerEyeAnchor;

        [InspectorButton(nameof(Center))]
        public Transform m_transform;

        private void Awake()
        {
            m_transform = transform;
            m_Canvas.gameObject.SetActive(true);
        }

        private void Start()
        {
            m_transform.parent = null;
        }

        private void Center()
        {
            transform.position = m_centerEyeAnchor.position;
            transform.rotation = m_centerEyeAnchor.rotation;
        }

        private void Update()
        {
            m_transform.position = m_centerEyeAnchor.position;
        }

        void FixedUpdate()
        {
            m_transform.rotation = Quaternion.Lerp(m_transform.rotation, m_centerEyeAnchor.rotation, 5.0f * Time.deltaTime);
        }
    }
}