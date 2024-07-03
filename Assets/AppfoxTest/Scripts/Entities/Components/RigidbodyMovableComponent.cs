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

        public override void MoveByDirection(Vector3 direction)
        {
            direction = direction.normalized;
            _rigidbody.MovePosition(transform.position + direction * Time.deltaTime * _movementSpeed);
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
