using UnityEngine;

namespace AppFoxTest
{
    [RequireComponent(typeof(MovableComponent))]
    [RequireComponent(typeof(PlayerTriggerHandlerComponent))]
    public class PlayerController : EntityController
    {
        private Vector3 _movementOnNextFrame;
        private Vector3 _lookAtPosition;

        protected IPlayerPresenter _playerPresenter => _presenter as IPlayerPresenter;

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
            _eventBus.OnSpell1ButtonPressed += OnSpell1ButtonPressed;
            _eventBus.OnSpell2ButtonPressed += OnSpell2ButtonPressed;
        }

        protected override sealed void RemoveListeners()
        {
            _eventBus.OnAttackButtonPressed -= OnAttackButtonPressed;
            _eventBus.OnAxisPressed -= OnAxisPressed;
            _eventBus.OnJumpButtonPressed -= OnJumpButtonPressed;
            _eventBus.OnMouseUpdate -= OnMouseUpdate;
            _eventBus.OnSpell1ButtonPressed -= OnSpell1ButtonPressed;
            _eventBus.OnSpell2ButtonPressed -= OnSpell2ButtonPressed;
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

        private void OnSpell2ButtonPressed()
        {
            _movable.LookAt(_lookAtPosition);
            UseSpell(1);
        }

        private void OnSpell1ButtonPressed()
        {
            _movable.LookAt(_lookAtPosition);
            UseSpell(0);
        }

        private void UseSpell(int index)
        {
            if (_availableSpells.Count > index)
            {
                SpellComponent spell = _availableSpells[index];
                if (_playerPresenter.TryUseSpell(spell.Spell))
                {
                    spell.Attack();
                }
            }
        }
    }
}
