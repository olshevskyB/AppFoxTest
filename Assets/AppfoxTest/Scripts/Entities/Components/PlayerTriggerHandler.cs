using UnityEngine;

namespace AppFoxTest
{
    public class PlayerTriggerHandler : EntityTriggerHandler
    {
        protected override void EnterTrigger(Collider other)
        {
            if (other.TryGetComponent(out NextLevelCube cube))
            {
                _sceneEventBus.OnInvokeNextLevel?.Invoke(cube.LevelSO);
            }
        }
    }
}