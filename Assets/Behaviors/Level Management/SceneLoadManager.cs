using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace DarkFramework
{
    public class SceneLoadManager : SingletonMonoBehavior<SceneLoadManager>
    {
        public AssetReference m_Playground;
        public AssetReference m_Landing;

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
            AssetReference targetScene = SceneManager.GetActiveScene().name == "Landing" ? m_Playground : m_Landing;
            AsyncOperationHandle<SceneInstance> environment = Addressables.LoadSceneAsync(targetScene, LoadSceneMode.Single, false);

            yield return environment;

            if (environment.Status == AsyncOperationStatus.Succeeded)
            {
                yield return environment.Result.ActivateAsync();
            }
        }
    }
}
