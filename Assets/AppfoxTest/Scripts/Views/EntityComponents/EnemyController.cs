using System.Collections.Generic;
using UnityEngine;

namespace AppFoxTest
{
    public class EnemyController : EntityController
    {
        private List<IEntityView> _enemies = new List<IEntityView>();

        [SerializeField]
        private float _radiusDetect;
        private float _radiusDetectSqr => _radiusDetect * _radiusDetect;

        [SerializeField]
        private float _radiusAttack;
        private float _radiusAttackSqr => _radiusAttack * _radiusAttack;

        private Transform _startPosition;

        private void Start()
        {
            if (TryGetComponent(out IHasStartPosition startPosition))
            {
                _startPosition = startPosition.StartPosition;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, _radiusDetect);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, _radiusAttack);
        }

        protected override void AddListeners()
        {
            _eventBus.OnPlayerSpawn += OnPlayerSpawn;
            _eventBus.OnEntityDead += OnEntityDead;
        }

        protected override void RemoveListeners()
        {
            _eventBus.OnPlayerSpawn -= OnPlayerSpawn;
            _eventBus.OnEntityDead -= OnEntityDead;
        }


        private void OnPlayerSpawn(IEntityView view)
        {
            _enemies.Add(view);
        }

        private void OnEntityDead(IEntityView view)
        {
            if (_enemies.Contains(view))
            {
                _enemies.Remove(view);
            }
        }

        private void Update()
        {
            float distance = 0f;
            IControlEntityView nearEnemy = null;
            foreach (IControlEntityView enemy in _enemies)
            {
                float currentDistance = (enemy.Transform.position - transform.position).sqrMagnitude;
                if (currentDistance <= _radiusDetectSqr)
                {
                    distance = currentDistance;
                    nearEnemy = enemy;
                    break;
                }
            }

            if (nearEnemy == null)
            {
                _movable.MoveByDestination(_startPosition.position);
                return;
            }

            _movable.LookAt(nearEnemy.Transform.position);
            _movable.MoveByDestination(nearEnemy.Transform.position);

            if (distance < _radiusAttackSqr)
            {
                _movable.MoveByDestination(transform.position);
                Attack();
            }
        }
    }
}
