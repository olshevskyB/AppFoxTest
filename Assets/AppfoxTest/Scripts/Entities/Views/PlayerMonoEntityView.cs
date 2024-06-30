namespace AppFoxTest
{
    public class PlayerMonoEntityView : MonoEntityView
    {
        private void Start()
        {
            _sceneEventBus.OnPlayerSpawn?.Invoke(this);
        }
    }
}
