using UnityEngine;

namespace AppFoxTest
{
    public class RigidbodyMovable : Movable
    {
        [SerializeField]
        private Rigidbody _rigidbody;

        public override void MoveByDirection(Vector3 direction)
        {
            direction = direction.normalized;
            _rigidbody.AddForce(direction * Time.deltaTime * 720f);
        }

        public override void Move(Vector3 movement)
        {
            _rigidbody.AddForce(movement * Time.deltaTime);
        }
    }
}
