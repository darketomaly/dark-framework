using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoadScene();
            }
        }

        private IEnumerator IELoadScene()
        {
            AsyncOperationHandle<SceneInstance> op = Addressables.LoadSceneAsync(m_Playground);

            while (!op.IsDone)
            {
                yield return null;
            }
        }
    }
}
