using UnityEngine;

namespace AppFoxTest
{
    public abstract class ProjectInstaller : Installer, IInitializable
    {
        public static ProjectInstaller Instance;

        public void Awake()
        {
            _diContainer = new DIContainer();
            GameObject.DontDestroyOnLoad(this);
            if (Instance != null)
            {
                Debug.LogError("ProjectInstaller already exist!");
                return;
            }
            Instance = this;
            Init();
        }
    }
}
