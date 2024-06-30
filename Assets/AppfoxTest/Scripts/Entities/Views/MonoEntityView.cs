using UnityEngine;

namespace AppFoxTest
{
    [RequireComponent(typeof(EntityTriggerHandler))]
    public class MonoEntityView : MonoBehaviour, IEntityView, IInjectable
    {
        private IEntityPresenter _entityPresentor;

        [SerializeField]
        private MovableComponent _movableComponent;

        [SerializeField]
        private AttackComponent _attackComponent;

        [SerializeField]
        private EntityTriggerHandler _entityTriggerHandler;

        protected SceneEventBus _sceneEventBus;

        private int _id;

        public Transform Transform => transform;

        public int ID 
        { 
            get => _id; 
            set => _id = value; 
        }

        public void Inject(DIContainer container)
        {
            _sceneEventBus = container.GetSingle<SceneEventBus>();
            _attackComponent.Owner = this;
            _entityTriggerHandler.SetView(this);
        }

        public void SetPresenter(IPresenter presenter)
        {
            if (presenter is IEntityPresenter entityPresenter)
            {
                _entityPresentor = entityPresenter;
            }
            else
            {
                Debug.LogError($"The presenter {presenter} is not an IEntityPresenter!");
            }
        }

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            transform.SetPositionAndRotation(position, rotation);
        }

        public void SetParent(Transform parent)
        {
            transform.parent = parent;
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
