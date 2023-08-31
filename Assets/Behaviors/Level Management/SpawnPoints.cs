#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

using UnityEngine;
using UnityEngine.SceneManagement;

namespace DarkFramework
{
    public class SpawnPoints : MonoBehaviour
    {
        public Transform[] m_SpawnPoints;
        
        #if UNITY_EDITOR

        [ContextMenu("Cache spawn points")]
        private void CacheSpawnPoints()
        {
            m_SpawnPoints = transform.GetChild(0).GetComponentsInChildren<Transform>();
            EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
        }
        
        #endif

        public Vector3 GetNextSpawn()
        {
            return m_SpawnPoints[0].position;
        }
    }
}