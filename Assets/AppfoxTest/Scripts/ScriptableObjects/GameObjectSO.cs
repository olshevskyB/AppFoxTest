using UnityEngine;

namespace AppFoxTest
{
    public abstract class GameObjectSO<T> : ScriptableObject where T: UnityEngine.Object
    {
        public abstract T Prefab
        {
            get;
        }
    }
}
