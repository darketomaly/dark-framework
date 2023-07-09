using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace DarkFramework
{
    public class SceneLoadManager : MonoBehaviour
    {
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
            AsyncOperationHandle<SceneInstance> environment = Addressables.LoadSceneAsync(m_Playground, LoadSceneMode.Single, false);

            yield return environment;

            if (environment.Status == AsyncOperationStatus.Succeeded)
            {
                yield return environment.Result.ActivateAsync();
            }
        }
    }
}
