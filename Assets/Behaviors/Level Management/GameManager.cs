using DarkFramework;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FPSPlayer m_FpsPlayer;

    private void Awake()
    {
        if (FPSPlayer.Instance)
        {
            //Destroy(m_FpsPlayer);
        }
    }
}
