using UnityEngine;

namespace AppFoxTest
{
    [RequireComponent(typeof(Collider))]
    public class EntityTriggerHandlerComponent : MonoBehaviour, IInjectable
    {
        protected SceneEventBus _sceneEventBus;

        protected IEntityView _entityView;

        private int _lastAttackId;

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
                if (_lastAttackId == attackComponent.AttackId)
                {
                    return;
                }
                if(_entityView != attackComponent.Owner)
                    _entityView.GetAttack(attackComponent.AttackValue);
                _lastAttackId = attackComponent.AttackId;
            }
            if (other.TryGetComponent(out KillBox killbox))
            {
                _entityView.GetAttack(10000);
            }
        }      
    }
}