using UnityEngine;

namespace AppFoxTest
{
    [RequireComponent(typeof(MovableComponent))]
    [RequireComponent(typeof(PlayerTriggerHandler))]
    public class PlayerController : EntityController
    {
        private void Update()
        {
            Debug.DrawLine(transform.position, transform.forward * 5f, Color.red);
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
            if(!_attackComponent.IsAttack)
                _movable.LookAt(position);
        }

        private void OnAttackButtonPressed()
        {
            Attack();
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
