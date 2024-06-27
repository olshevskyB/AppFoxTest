using UnityEngine;

namespace AppFoxTest
{
    [RequireComponent(typeof(Collider))]
    public abstract class EntityTriggerHandler : MonoBehaviour, IInjectable
    {
        protected SceneEventBus _sceneEventBus;

        public void Inject(DIContainer container)
        {
            _sceneEventBus = container.GetSingle<SceneEventBus>();
        }

        private void OnTriggerEnter(Collider other)
        {
            EnterTrigger(other);
        }

        protected virtual void EnterTrigger(Collider other)
        {

        }      
    }
}