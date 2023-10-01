using UnityEngine;

namespace DarkFramework
{
    public class GameManager : MonoBehaviour
    {
        public FPSPlayer m_FpsPlayer;

        private void Awake()
        {
            if (!FPSPlayer.Instance)
            {
                Instantiate(m_FpsPlayer);
            }
        }
    }
}
