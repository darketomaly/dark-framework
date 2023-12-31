using System;
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
        public Level[] m_Levels;
        public Action<LeveLReference> OnSceneLoaded;

        private readonly Dictionary<LeveLReference, Level> m_levelsDictionary = new();
        private Level m_currentLevel;

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
                    Debug.LogError($"<color=olive>Loading splash</color>");
                    LoadScene(LeveLReference.Splash);
                }
                else
                {
                    Debug.LogError($"<color=olive>Loading playground. Current scene is {SceneManager.GetActiveScene().name}</color>");
                    LoadScene(LeveLReference.Playground);
                }
            }
        }
        
        private void LoadScene(LeveLReference levelToLoad)
        {
            if (m_loadingSceneCoroutine != null)
            {
                Debug.LogError($"<color=olive>Tried to load {levelToLoad}, but there's an active loading coroutine!</color>");
                return;
            }
            
            m_loadingSceneCoroutine = StartCoroutine(IELoadScene(levelToLoad));
        }

        private SceneInstance m_lastActivatedScene;
        private Coroutine m_loadingSceneCoroutine;

        private IEnumerator IELoadScene(LeveLReference levelToLoad)
        {
            AsyncOperationHandle<SceneInstance> loadingScene = Addressables.LoadSceneAsync(m_levelsDictionary[LeveLReference.Loading].m_Asset, LoadSceneMode.Additive, false);

            OVRScreenFade.instance.FadeOut();
            yield return new WaitForSeconds(2);
            
            yield return loadingScene;

            if (loadingScene.Status == AsyncOperationStatus.Succeeded)
            {
                yield return 0;
                
                loadingScene.Result.ActivateAsync();
                OnSceneLoaded?.Invoke(LeveLReference.Loading);
                OVRScreenFade.instance.FadeIn();
                
                yield return 0;
                
                if (SceneManager.GetActiveScene().name == LeveLReference.Splash.ToString())
                {
                    yield return SceneManager.UnloadSceneAsync("Splash");
                }
                else
                {
                    Addressables.UnloadSceneAsync(m_lastActivatedScene);
                }
            }
            else
            {
                Debug.LogError($"<color=olive>Failed to load loading scene.</color>");
                yield break;
            }

            yield return new WaitForSeconds(3); //fake loading time
            
            AsyncOperationHandle<SceneInstance> environment = Addressables.LoadSceneAsync(m_levelsDictionary[levelToLoad].m_Asset, LoadSceneMode.Additive, false);

            OVRScreenFade.instance.FadeOut();
            yield return new WaitForSeconds(2);
            
            yield return environment;

            if (environment.Status == AsyncOperationStatus.Succeeded)
            {
                m_lastActivatedScene = environment.Result;
                
                yield return 0;
                yield return environment.Result.ActivateAsync();
                OnSceneLoaded?.Invoke(levelToLoad);
                yield return 0;
                Addressables.UnloadSceneAsync(loadingScene);
                
                OVRScreenFade.instance.FadeIn();
            }

            m_loadingSceneCoroutine = null;
        }
    }
}
