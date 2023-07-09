using DarkFramework;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private SpawnPoints m_spawnPoints;

    private void Start()
    {
        m_spawnPoints = FindObjectOfType<SpawnPoints>();
        FPSPlayer.Instance.Teleport(m_spawnPoints.GetNextSpawn());
    }
}
