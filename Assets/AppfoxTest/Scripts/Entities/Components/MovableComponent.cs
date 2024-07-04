using UnityEngine;

namespace AppFoxTest
{
    public abstract class MovableComponent : MonoBehaviour
    {
        protected float _movementSpeed;

        public abstract void LookAt(Vector3 position);

        public abstract void MoveByDirection(Vector3 direction, float deltaTime);

        public abstract void MoveByDestination(Vector3 destination);

        public abstract void Jump();

        public virtual void UpdateMovementSpeed(float value)
        {
            _movementSpeed = value;
        }

        public virtual void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}
