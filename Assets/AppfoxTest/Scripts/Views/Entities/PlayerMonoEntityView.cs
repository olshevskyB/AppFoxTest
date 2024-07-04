namespace AppFoxTest
{
    public class PlayerMonoEntityView : MonoEntityView, IPlayerEntityView
    {
        IPlayerPresenter PlayerPresenter => _presenter as IPlayerPresenter;

        private void Start()
        {
            _sceneEventBus.OnPlayerSpawn?.Invoke(this);
        }

        public override void Death()
        {
            base.Death();
            _sceneEventBus.OnPlayerDeath?.Invoke(this);
        }

        public void Collect(ICollectable collectable)
        {
            PlayerPresenter.Collect(collectable);
        }
    }
}
