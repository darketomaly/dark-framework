using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public Transform[] m_SpawnPoints; 
    
    [ContextMenu("Cache spawn points")]
    private void CacheSpawnPoints()
    {
        m_SpawnPoints = transform.GetChild(0).GetComponentsInChildren<Transform>();
    }

    private Vector3 GetNextSpawn()
    {
        return m_SpawnPoints[0].position;
    }
}
