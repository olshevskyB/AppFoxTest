using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AppFoxTest
{
    public class SceneLoader : MonoBehaviour, ISceneLoader
    {
        public void LoadScene(SceneSO sceneSO, Action<SceneSO> onLoad, Action<SceneSO, float> onProgress)
        {
            StartCoroutine(LoadSceneAsync(sceneSO, onLoad, onProgress));
        }

        private IEnumerator LoadSceneAsync(SceneSO sceneSO, Action<SceneSO> onLoad, Action<SceneSO, float> onProgress)
        {
            var asyncLoad = SceneManager.LoadSceneAsync(sceneSO.Index, sceneSO.SceneMode);
            while (!asyncLoad.isDone)
            {
                onProgress.Invoke(sceneSO, asyncLoad.progress);
                yield return null;
            }
            onLoad.Invoke(sceneSO);
        }
    }
}