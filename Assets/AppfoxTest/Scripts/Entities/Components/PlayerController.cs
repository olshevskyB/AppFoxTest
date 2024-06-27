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

        public void Inject(DIContainer container)
        {
            _eventBus = container.GetSingle<SceneEventBus>();
            AddListeners();
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
        }

        private void RemoveListeners()
        {
            _eventBus.OnAttackButtonPressed -= OnAttackButtonPressed;
            _eventBus.OnAxisPressed -= OnAxisPressed;
            _eventBus.OnJumpButtonPressed -= OnJumpButtonPressed;
        }
        private void OnAttackButtonPressed()
        {
            Debug.Log("Attack!");
        }

        private void OnAxisPressed(Vector2 vector)
        {
            Vector3 floorVector = new Vector3(vector.x, 0f, vector.y);
            _movable.MoveByDirection(floorVector * 15f);
        }

        private void OnJumpButtonPressed()
        {
            _movable.Move(Vector3.up * 100f);
        }
    }
}
