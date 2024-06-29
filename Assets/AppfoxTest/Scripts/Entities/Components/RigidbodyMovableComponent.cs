using UnityEngine;

namespace AppFoxTest
{
    public class RigidbodyMovableComponent : MovableComponent
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

        public override void LookAt(Vector3 position)
        {
            position = new Vector3(position.x, transform.position.y, position.z);
            transform.LookAt(position, Vector3.up);
        }
    }
}
