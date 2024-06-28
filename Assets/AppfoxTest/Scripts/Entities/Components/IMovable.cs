using UnityEngine;

namespace AppFoxTest
{
    public abstract class Movable : MonoBehaviour
    {
        public abstract void LookAt(Vector3 position);

        public abstract void MoveByDirection(Vector3 direction);

        public abstract void Move(Vector3 movement);

        public virtual void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}
