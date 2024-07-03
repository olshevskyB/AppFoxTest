using UnityEngine;

namespace AppFoxTest
{
    public class PlayerTriggerHandler : EntityTriggerHandler
    {
        protected override void EnterTrigger(Collider other)
        {
            base.EnterTrigger(other);
            if (other.TryGetComponent(out NextLevelCube cube))
            {
                _sceneEventBus.OnInvokeLevel?.Invoke(cube.Level);
            }
        }
    }
}