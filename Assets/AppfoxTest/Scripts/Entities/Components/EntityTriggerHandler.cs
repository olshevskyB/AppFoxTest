using UnityEngine;

namespace AppFoxTest
{
    [RequireComponent(typeof(Collider))]
    public abstract class EntityTriggerHandler : MonoBehaviour, IInjectable
    {
        protected SceneEventBus _sceneEventBus;

        private IEntityView _entityView;

        public void Inject(DIContainer container)
        {
            _sceneEventBus = container.GetSingle<SceneEventBus>();
        }

        public void SetView(IEntityView view)
        {
            _entityView = view;
        }

        private void OnTriggerEnter(Collider other)
        {
            EnterTrigger(other);
        }

        protected virtual void EnterTrigger(Collider other)
        {
            if (other.TryGetComponent(out HurtBoxComponent hurtBox))
            {
                AttackComponent attackComponent = hurtBox.AttackComponent;
                if(_entityView != attackComponent.Owner)
                    _entityView.GetAttack(attackComponent.AttackValue);
            }
        }      
    }
}