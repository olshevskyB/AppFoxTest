using UnityEngine;

namespace AppFoxTest
{
    public abstract class EntityController : MonoBehaviour, IInjectable
    {
        protected SceneEventBus _eventBus;

        [SerializeField]
        protected MovableComponent _movable;

        [SerializeField]
        protected AttackComponent _attackComponent;

        public void Inject(DIContainer container)
        {
            _eventBus = container.GetSingle<SceneEventBus>();
            AddListeners();
        }

        protected void Attack()
        {
            _attackComponent.Attack();
        }

        protected abstract void AddListeners();

        protected abstract void RemoveListeners();
    }
}
