using UnityEngine;

namespace AppFoxTest
{
    [RequireComponent(typeof(Movable))]
    [RequireComponent(typeof(PlayerTriggerHandler))]
    public class PlayerController : EntityController, IInjectable
    {
        private SceneEventBus _eventBus;

        [SerializeField]
        private Movable _movable;

        [SerializeField]
        private AttackComponent _attackComponent;

        public void Inject(DIContainer container)
        {
            _eventBus = container.GetSingle<SceneEventBus>();
            AddListeners();
        }

        private void Update()
        {
            Debug.DrawLine(transform.position, transform.forward * 5f, Color.red);
        }

        private void OnDestroy()
        {
            RemoveListeners();
        }

        private void AddListeners()
        {
            _eventBus.OnAttackButtonPressed += OnAttackButtonPressed;
            _eventBus.OnAxisPressed += OnAxisPressed;
            _eventBus.OnJumpButtonPressed += OnJumpButtonPressed;
            _eventBus.OnMouseUpdate += OnMouseUpdate;
        }

        private void RemoveListeners()
        {
            _eventBus.OnAttackButtonPressed -= OnAttackButtonPressed;
            _eventBus.OnAxisPressed -= OnAxisPressed;
            _eventBus.OnJumpButtonPressed -= OnJumpButtonPressed;
            _eventBus.OnMouseUpdate -= OnMouseUpdate;
        }

        private void OnMouseUpdate(Vector3 position)
        {
            //_movable.LookAt(new Vector3(position.x, transform.position.y, position.z));
            _movable.LookAt(position);
        }

        private void OnAttackButtonPressed()
        {
            _attackComponent.Attack();
        }

        private void OnAxisPressed(Vector2 vector)
        {
            Vector3 floorVector = new Vector3(vector.x, 0f, vector.y);
            _movable.MoveByDirection(floorVector * 15f);
        }

        private void OnJumpButtonPressed()
        {
            _movable.Move(Vector3.up * 25000f);
        }
    }
}
