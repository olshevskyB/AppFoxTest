using UnityEngine;

namespace AppFoxTest
{
    public interface IControlEntityView : IEntityView, IHasStartPosition
    {
        public Transform Transform
        {
            get;
        }

        public EntityController Controller
        {
            get;
        }

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation);

        public void SetParent(Transform parent);        
    }
}

