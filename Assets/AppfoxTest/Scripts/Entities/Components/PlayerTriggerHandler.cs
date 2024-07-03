using UnityEngine;

namespace AppFoxTest
{
    public class PlayerTriggerHandler : EntityTriggerHandler
    {
        private IPlayerEntityView _playerEntityView => _entityView as IPlayerEntityView;

        protected override void EnterTrigger(Collider other)
        {
            base.EnterTrigger(other);
            if (other.TryGetComponent(out NextLevelCube cube))
            {
                _sceneEventBus.OnInvokeLevel?.Invoke(cube.Level);
                return;
            }
            if (other.TryGetComponent(out ICollectable collectable))
            {
                _playerEntityView.Collect(collectable);                
            }
        }
    }
}