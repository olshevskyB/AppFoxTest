using UnityEngine;
using UnityEngine.AI;

namespace AppFoxTest
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavMeshMovable : MovableComponent
    {
        [SerializeField]
        private NavMeshAgent _meshAgent;
        private void OnValidate()
        {
            _meshAgent = GetComponent<NavMeshAgent>();
        }

        public override void UpdateMovementSpeed(float value)
        {
            base.UpdateMovementSpeed(value);
            _meshAgent.speed = value;
        }

        public override void LookAt(Vector3 position)
        {
            position = new Vector3(position.x, transform.position.y, position.z);
            transform.LookAt(position, Vector3.up);
        }

        public override void Move(Vector3 movement)
        {
            transform.position += movement;
        }

        public override void MoveByDirection(Vector3 direction)
        {
            transform.position += direction.normalized * Time.deltaTime * _movementSpeed;
        }

        public override void MoveByDestination(Vector3 destination)
        {
            _meshAgent.SetDestination(destination);
        }
    }
}
