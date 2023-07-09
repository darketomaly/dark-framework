using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DarkFramework
{
    public class SpawnPoints : MonoBehaviour
    {
        public Transform[] m_SpawnPoints;

        [ContextMenu("Cache spawn points")]
        private void CacheSpawnPoints()
        {
            m_SpawnPoints = transform.GetChild(0).GetComponentsInChildren<Transform>();
            EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
        }

        public Vector3 GetNextSpawn()
        {
            return m_SpawnPoints[0].position;
        }
    }
}
