using UnityEngine;

namespace AppFoxTest
{
    [RequireComponent(typeof(MovableComponent))]
    [RequireComponent(typeof(PlayerTriggerHandlerComponent))]
    public class PlayerController : EntityController
    {
        private Vector3 _movementOnNextFrame;
        private Vector3 _lookAtPosition;

        public void FixedUpdate()
        {
            _movable.MoveByDirection(_movementOnNextFrame, Time.fixedDeltaTime);
            _movementOnNextFrame = Vector3.zero;
        }

        private void OnDestroy()
        {
            RemoveListeners();
        }

        protected override sealed void AddListeners()
        {
            _eventBus.OnAttackButtonPressed += OnAttackButtonPressed;
            _eventBus.OnAxisPressed += OnAxisPressed;
            _eventBus.OnJumpButtonPressed += OnJumpButtonPressed;
            _eventBus.OnMouseUpdate += OnMouseUpdate;
        }

        protected override sealed void RemoveListeners()
        {
            _eventBus.OnAttackButtonPressed -= OnAttackButtonPressed;
            _eventBus.OnAxisPressed -= OnAxisPressed;
            _eventBus.OnJumpButtonPressed -= OnJumpButtonPressed;
            _eventBus.OnMouseUpdate -= OnMouseUpdate;
        }

        private void OnMouseUpdate(Vector3 position)
        {
            _lookAtPosition = position;
        }

        private void OnAttackButtonPressed()
        {
            if (!_attackComponent.IsAttack)
            {
                _movable.LookAt(_lookAtPosition);
                Attack();
            }          
        }

        private void OnAxisPressed(Vector2 vector)
        {
            Vector3 floorVector = new Vector3(vector.x, 0f, vector.y);
            _movementOnNextFrame = floorVector;           
        }

        private void OnJumpButtonPressed()
        {
            _movable.Jump();
        }
    }
}
