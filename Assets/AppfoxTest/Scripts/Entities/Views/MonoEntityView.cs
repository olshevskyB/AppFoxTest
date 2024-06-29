using UnityEngine;

namespace AppFoxTest
{
    public class MonoEntityView : MonoBehaviour, IEntityView, IInjectable
    {
        private IEntityPresentor _entityPresentor;

        [SerializeField]
        private MovableComponent _movableComponent;

        [SerializeField]
        private AttackComponent _attackComponent;

        private SceneEventBus _sceneEventBus;

        private int id;
        public int ID => id;

        public void Inject(DIContainer container)
        {
            _sceneEventBus = container.GetSingle<SceneEventBus>();
            _attackComponent.Owner = this;
        }

        public void SetHP(float hp)
        {
            if (hp <= 0f)
            {
                Death();
            }
        }

        public void SetMovementSpeed(float speed)
        {
            _movableComponent.UpdateMovementSpeed(speed);
        }

        public void SetAttack(float attack)
        {
            _attackComponent.UpdateAttackValue(attack);
        }

        public void GetAttack(float attack)
        {
            _entityPresentor.GetAttack(attack);
        }

        public virtual void Death()
        {
            _sceneEventBus.OnEntityDead?.Invoke(this);
        }       
    }
}
