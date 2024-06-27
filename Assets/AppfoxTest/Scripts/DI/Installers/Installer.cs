using UnityEngine;

namespace AppFoxTest
{
    public abstract class Installer : MonoBehaviour, IInitializable
    {
        protected DIContainer _diContainer;

        public abstract void Init();

        public void Inject(IInjectable injectable)
        {
            _diContainer.Inject(injectable);
        }

        protected void SetTransformForNewGameObject(Transform transform)
        {
            transform.parent = gameObject.transform;
        }

        protected T CreateAsGameObject<T>() where T : MonoBehaviour
        {
            GameObject gameObject = new GameObject(typeof(T).ToString());
            T newComponent = gameObject.AddComponent<T>();
            SetTransformForNewGameObject(gameObject.transform);
            return newComponent;
        }
    }
}
