using System.Collections.Generic;
using UnityEngine;

namespace AppFoxTest
{
    [RequireComponent(typeof(MonoTimer))]
    public abstract class AttackComponent : MonoBehaviour
    {
        [SerializeField]
        protected EntityController _owner;

        [SerializeField]
        protected List<Collider> _hurtBoxes;

        [SerializeField]
        private float _attackTime;

        private ITimer _timer;

        private void Awake()
        {
            _timer = GetComponent<MonoTimer>();
        }

        public void Attack()
        {
            if (!_timer[this])//Если таймер для этого объекта не запущен
            {
                StartAttack();
            }
        }

        protected virtual void OnStartAttack()
        {
            EnableHurtBox();
        }

        protected abstract void UpdateAttack(float time, float progress);

        protected virtual void OnEndAttack()
        {
            DisableHurtBox();
        }

        private void StartAttack()
        {
            OnStartAttack();      
            _timer.StartTimer(OnEndAttack, UpdateAttack, _attackTime, this);
        }

        private void EnableHurtBox()
        {
            foreach(Collider hurBox in _hurtBoxes)
            {
                hurBox.enabled = true;
            }
        }

        private void DisableHurtBox()
        {
            foreach (Collider hurBox in _hurtBoxes)
            {
                hurBox.enabled = false;
            }
        }
    }
}
