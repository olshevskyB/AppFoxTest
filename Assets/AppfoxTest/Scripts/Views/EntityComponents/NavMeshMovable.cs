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

        public override void MoveByDirection(Vector3 direction, float deltaTime)
        {
            _meshAgent.SetDestination(transform.position + direction.normalized);
        }

        public override void MoveByDestination(Vector3 destination)
        {
            _meshAgent.SetDestination(destination);
        }

        public override void Jump()
        {
            
        }
    }
}
