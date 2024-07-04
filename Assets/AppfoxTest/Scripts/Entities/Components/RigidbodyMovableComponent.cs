using UnityEngine;

namespace AppFoxTest
{
    public class RigidbodyMovableComponent : MovableComponent
    {
        [SerializeField]
        private Rigidbody _rigidbody;

        [SerializeField]
        private float _jumpForce = 10f;

        [SerializeField]
        private Transform _raycastOrigin;

        [SerializeField]
        private float _raycastDistance;

        [SerializeField]
        private float _velocity = 30f;

        private bool _canDoJump
        {
            get
            {
                if (Physics.Raycast(_raycastOrigin.position, -transform.up, out RaycastHit hit, _raycastDistance))
                {
                    return true;
                }
                return false;
            }
        }

        public override void MoveByDirection(Vector3 direction, float deltaTime)
        {
            direction = direction.normalized;
            Vector3 movement = _movementSpeed * _velocity * deltaTime * direction;
            _rigidbody.velocity = new Vector3(movement.x, _rigidbody.velocity.y, movement.z);
        }

        public override void LookAt(Vector3 position)
        {
            position = new Vector3(position.x, transform.position.y, position.z);
            transform.LookAt(position, Vector3.up);
        }

        public override void MoveByDestination(Vector3 destination)
        {
            transform.position = destination;
        }

        public override void Jump()
        {
            if (_canDoJump)
            {
                _rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
            }
        }
    }
}
