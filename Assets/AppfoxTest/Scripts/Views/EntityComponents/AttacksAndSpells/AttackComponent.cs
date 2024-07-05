using System;
using System.Collections.Generic;
using UnityEngine;

namespace AppFoxTest
{
    [RequireComponent(typeof(MonoTimer))]
    public abstract class AttackComponent : MonoBehaviour
    {
        protected IEntityView _owner;

        public IEntityView Owner
        {
            get
            {
                return _owner;
            }
            set
            {
                _owner = value;
            }
        }

        [SerializeField]
        protected List<Collider> _hurtBoxes;

        [SerializeField]
        private float _attackTime;

        private ITimer _timer;

        protected float _attack;

        public bool IsAttack => _timer[this];

        private int _attackId;

        public int AttackId => _attackId;

        public float AttackValue
        {
            get
            {
                return _attack;
            }
        }

        private void Awake()
        {
            _timer = GetComponent<MonoTimer>();
        }

        public void UpdateAttackValue(float attack)
        {
            _attack = attack;
        }

        public void Attack()
        {
            if (!IsAttack)
            {
                StartAttack();
            }
        }     

        protected virtual void OnStartAttack()
        {
            _attackId = Time.frameCount;
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
