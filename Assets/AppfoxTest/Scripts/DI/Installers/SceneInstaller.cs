namespace AppFoxTest
{
    public abstract class SceneInstaller : Installer, IInjectable
    {
        public void Awake()
        {
            ProjectInstaller.Instance.Inject(this);
            Init();
        }

        public void Inject(DIContainer container)
        {
            _diContainer = container;
        }
    }
}
