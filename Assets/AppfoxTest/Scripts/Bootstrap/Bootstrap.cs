using UnityEngine;

namespace AppFoxTest
{
    public class Bootstrap : ProjectInstaller
    {
        [SerializeField] private SceneService _sceneManager;
        [SerializeField] private ScenesConfig _scenesConfig;

        public override void Init()
        {          
            _diContainer.AddNewObjectAndInit(new GlobalEventBus());
            _diContainer.AddNewObjectAndInit(_scenesConfig);

            ISceneLoader sceneLoader = CreateAsGameObject<SceneLoader>();
            _diContainer.AddNewObjectAndInit(sceneLoader);
            _diContainer.AddNewObjectAndInit(_sceneManager);
        }
    }
}
