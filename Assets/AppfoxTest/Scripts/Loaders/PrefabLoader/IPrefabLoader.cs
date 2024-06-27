using System;
using UnityEngine;

namespace AppFoxTest
{
    public interface IPrefabLoader
    {
        public T Load<T>(T prefab) where T : UnityEngine.Object;

        public void Load<T>(GameObjectSO<T> so, Action<T> onLoaded, Action<GameObjectSO<T>, float> onProgress = null) where T : UnityEngine.Object;
    }
}
