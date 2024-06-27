using System;

namespace AppFoxTest
{
    public interface IPrefabLoader
    {
        public T Load<T>(T prefab, IUnloader unloader) where T : UnityEngine.Object;

        public void Load<T>(GameObjectSO<T> so, IUnloader unloader, Action<T> onLoaded, Action<GameObjectSO<T>, float> onProgress = null) where T : UnityEngine.Object;
    }
}
