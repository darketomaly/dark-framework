using Oculus.Interaction;
using UnityEngine;

namespace DarkFramework
{
    public class DisplayCamera : MonoBehaviour
    {
        public Canvas m_Canvas;
    
        public Transform m_LeftEyeAnchor;
        public Transform m_RightEyeAnchor;
        public Transform m_CenterEyeAnchor;

        [InspectorButton(nameof(Center))]
        public Transform m_Transform;

        private void Awake()
        {
            m_Transform = transform;
            m_Canvas.gameObject.SetActive(true);
        }

        private void Start()
        {
            m_Transform.parent = null;
        }

        private void Center()
        {
            transform.position = m_CenterEyeAnchor.position;
            transform.rotation = m_CenterEyeAnchor.rotation;
        }

        private void Update()
        {
            m_Transform.position = m_CenterEyeAnchor.position;
        }

        void FixedUpdate()
        {
            m_Transform.rotation = Quaternion.Lerp(m_Transform.rotation, m_CenterEyeAnchor.rotation, 5.0f * Time.deltaTime);
        }
    }
}