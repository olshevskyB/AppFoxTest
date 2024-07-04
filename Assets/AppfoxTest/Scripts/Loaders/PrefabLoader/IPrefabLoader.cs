using System;
using UnityEngine;

namespace AppFoxTest
{
    public interface IPrefabLoader
    {
        public T Load<T>(T prefab, IUnloader unloader, Transform parent = null) where T : UnityEngine.Object;

        public T Load<T>(T prefab, IUnloader unloader, Vector3 position, Quaternion rotation, Transform parent = null) where T : UnityEngine.Object;

        public void LoadAsync<T>(GameObjectSO<T> so, IUnloader unloader, Action<T> onLoaded, Action<GameObjectSO<T>, float> onProgress = null, Transform parent = null) where T : UnityEngine.Object;
    }
}
