using System.Collections;
using System.Collections.Generic;
using DarkFramework;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace DarkFramework
{
    public class SceneLoadManager : MonoBehaviour
    {
        public DataManager m_DataManager;

        public AssetReference m_Playground;

        [ContextMenu("Load Playground")]
        public void LoadScene()
        {
            StartCoroutine(IELoadScene());
        }

        private IEnumerator IELoadScene()
        {
            yield return null;
        }
    }
}
