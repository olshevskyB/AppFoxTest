using System;

namespace AppFoxTest
{
    public interface IPrefabLoader
    {
        public void Load<T>(GameObjectSO<T> so, Action<T> onLoaded, Action<GameObjectSO<T>, float> onProgress) where T : UnityEngine.Object;
    }
}
