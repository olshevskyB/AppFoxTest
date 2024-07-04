using UnityEngine;

namespace AppFoxTest
{
    public class PlayerTriggerHandlerComponent : EntityTriggerHandlerComponent
    {
        private IPlayerEntityView _playerEntityView => _entityView as IPlayerEntityView;

        protected override void EnterTrigger(Collider other)
        {
            base.EnterTrigger(other);
            if (other.TryGetComponent(out ICollectable collectable))
            {
                _playerEntityView.Collect(collectable);                
            }
        }
    }
}