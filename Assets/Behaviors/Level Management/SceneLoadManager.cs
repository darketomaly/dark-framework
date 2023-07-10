using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace DarkFramework
{
    public class SceneLoadManager : SingletonMonoBehavior<SceneLoadManager>
    {
        public AssetReference m_Logic;
        
        public Level[] m_Levels;

        private readonly Dictionary<LeveLReference, Level> m_levelsDictionary = new();

        protected override void Awake()
        {
            base.Awake();

            foreach (Level level in m_Levels)
            {
                m_levelsDictionary.Add(level.m_Name, level);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (SceneManager.GetActiveScene().name == LeveLReference.Playground.ToString())
                {
                    LoadScene(LeveLReference.Landing);
                }
                else
                {
                    LoadScene(LeveLReference.Playground);
                }
            }
        }
        
        private void LoadScene(LeveLReference levelToLoad)
        {
            StartCoroutine(IELoadScene(levelToLoad));
        }

        private IEnumerator IELoadScene(LeveLReference levelToLoad)
        {
            AsyncOperationHandle<SceneInstance> environment = Addressables.LoadSceneAsync(m_levelsDictionary[levelToLoad].m_Asset, LoadSceneMode.Single, false);

            yield return environment;

            if (environment.Status == AsyncOperationStatus.Succeeded)
            {
                yield return environment.Result.ActivateAsync();
            }
        }
    }
}
