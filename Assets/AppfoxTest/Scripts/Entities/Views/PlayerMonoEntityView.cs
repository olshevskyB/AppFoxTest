namespace AppFoxTest
{
    public class PlayerMonoEntityView : MonoEntityView
    {
        private void Start()
        {
            _sceneEventBus.OnPlayerSpawn?.Invoke(this);
        }

        public override void Death()
        {
            base.Death();
            _sceneEventBus.OnPlayerDeath?.Invoke(this);
        }
    }
}
