using UnityEngine;

namespace AppFoxTest
{
    [RequireComponent(typeof(EntityTriggerHandlerComponent))]
    public class MonoEntityView : AbstractMonoView, IControlEntityView
    {
        private IEntityPresenter EntityPresenter => _presenter as IEntityPresenter;

        [SerializeField]
        private MovableComponent _movableComponent;

        [SerializeField]
        private AttackComponent _attackComponent;

        [SerializeField]
        private EntityTriggerHandlerComponent _entityTriggerHandler;

        [SerializeField]
        private EntityController _entityController;

        protected SceneEventBus _sceneEventBus;

        private int _id;

        private EntitySO _entitySO;

        public Transform Transform => transform;

        public int ID 
        { 
            get => _id; 
            set => _id = value; 
        }
        public Transform StartPosition 
        { 
            get;
            set ; 
        }

        public EntityController Controller => _entityController;


        public override void Inject(DIContainer container)
        {
            base.Inject(container);
            _sceneEventBus = container.GetSingle<SceneEventBus>();
            _globalEventBus = container.GetSingle<GlobalEventBus>();
            _attackComponent.Owner = this;
            _entityTriggerHandler.SetView(this);
        }

        public override void SetPresenter(IPresenter presenter)
        {
            if (presenter is IEntityPresenter entityPresenter)
            {
                _presenter = entityPresenter;
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
            EntityPresenter.GetAttack(attack);
        }

        public virtual void Death()
        {
            _sceneEventBus.OnEntityDead?.Invoke(this);
            _globalEventBus.OnUnloadEntity?.Invoke(this);
        }

        public void SetConfig(EntitySO so)
        {
            _entitySO = so;
        }
    }
}
