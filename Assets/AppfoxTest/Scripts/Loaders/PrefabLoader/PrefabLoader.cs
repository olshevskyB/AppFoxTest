using System;
using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace AppFoxTest
{
    public class PrefabLoader : MonoBehaviour, IPrefabLoader, IInjectable
    {
        private DIContainer _container;      

        public void Inject(DIContainer container)
        {
            _container = container;
        }

        public void LoadAsync<T>(GameObjectSO<T> so, IUnloader unloader, Action<T> onLoaded, Action<GameObjectSO<T>, float> onProgress = null, Transform parent = null) where T : UnityEngine.Object
        {
            StartCoroutine(StartLoading(so, unloader, onLoaded, onProgress, parent));
        }

        public T Load<T>(T prefab, IUnloader unloader, Transform parent = null) where T : UnityEngine.Object
        {
            var result = Instantiate(prefab, parent);
            InjectObjects(result);
            unloader.AddObject(result.GameObject());
            return result;
        }

        private IEnumerator StartLoading<T>(GameObjectSO<T> so, IUnloader unloader, Action<T> onLoaded, Action<GameObjectSO<T>, float> onProgress = null, Transform parent = null) where T : UnityEngine.Object
        {
            var asyncLoad = InstantiateAsync(so.Prefab, parent);
            while (!asyncLoad.isDone)
            {
                onProgress?.Invoke(so, asyncLoad.progress);
                yield return null;
            }
            var result = asyncLoad.Result.First();
            InjectObjects(result);
            unloader.AddObject(result.GameObject());
            onLoaded.Invoke(result);
        }

        private void InjectObjects<T>(T newObject) where T : UnityEngine.Object
        {
            IInjectable[] injectables = newObject.GetComponentsInChildren<IInjectable>();
            for (int i = 0; i < injectables.Length; i++)
            {
                injectables[i].Inject(_container);
            }
        }
    }
}
