using UnityEngine;

namespace AppFoxTest
{
    public interface IEntityView : IView, IInitializable
    {
        public int ID
        {
            get;
            set;
        }

        public Transform Transform
        {
            get;
        }

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation);

        public void SetParent(Transform parent);

        public void SetHP(float hp);

        public void SetMovementSpeed(float speed);

        public void SetAttack(float attack);

        public void GetAttack(float attack);
    }
}
