using UnityEngine;

namespace AppFoxTest
{
    public interface IControlEntityView : IEntityView
    {
        public Transform Transform
        {
            get;
        }

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation);

        public void SetParent(Transform parent);
    }
}

