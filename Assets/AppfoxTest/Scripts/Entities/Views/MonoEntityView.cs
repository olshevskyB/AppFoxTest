using UnityEngine;

namespace AppFoxTest
{
    [RequireComponent(typeof(EntityTriggerHandler))]
    public class MonoEntityView : AbstractMonoView, IEntityView
    {
        private IEntityPresenter _entityPresenter;

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

        public override void Inject(DIContainer container)
        {
            base.Inject(container);
            _sceneEventBus = container.GetSingle<SceneEventBus>();
            _attackComponent.Owner = this;
            _entityTriggerHandler.SetView(this);
        }

        public override void SetPresenter(IPresenter presenter)
        {
            if (presenter is IEntityPresenter entityPresenter)
            {
                _entityPresenter = entityPresenter;
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
            Debug.Log("Attacked " + ID);
            _entityPresenter.GetAttack(attack);
        }

        public virtual void Death()
        {
            _sceneEventBus.OnEntityDead?.Invoke(this);
        }

    }
}
