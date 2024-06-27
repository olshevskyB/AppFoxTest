using System;
using System.Collections;
using UnityEngine;

namespace AppFoxTest
{
    public class PrefabLoader : MonoBehaviour, IPrefabLoader
    {
        public void Load<T>(GameObjectSO<T> so, Action<T> onLoaded, Action<GameObjectSO<T>, float> onProgress) where T : UnityEngine.Object
        {
            StartCoroutine(StartLoading(so, onLoaded, onProgress));
        }

        private IEnumerator StartLoading<T>(GameObjectSO<T> so, Action<T> onLoaded, Action<GameObjectSO<T>, float> onProgress) where T : UnityEngine.Object
        {
            var asyncLoad = InstantiateAsync(so.Prefab);
            while (!asyncLoad.isDone)
            {
                onProgress?.Invoke(so, asyncLoad.progress);
                yield return null;
            }

            onLoaded.Invoke(asyncLoad.Result as T);
        }
    }
}
