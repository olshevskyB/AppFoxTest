using UnityEngine;

namespace AppFoxTest
{
    public class MainInstaller : ProjectInstaller
    {
        [SerializeField] private SceneService _sceneManager;
        [SerializeField] private ScenesConfig _scenesConfig;
        [SerializeField] private ScreensConfig _screensConfig;

        public override void Init()
        {
            _diContainer.AddNewObjectAndInit(new GlobalEventBus());
            _diContainer.AddNewObjectAndInit(new SceneEventBus());
            _diContainer.AddNewObjectAndInit(_scenesConfig);
            _diContainer.AddNewObjectAndInit(_screensConfig);

            _diContainer.AddNewObjectAndInit(CreateAsGameObject<ModelLocator>());

            _diContainer.AddNewObjectAndInit(new Unloader());
            _diContainer.AddNewObjectAndInit(CreateAsGameObject<PrefabLoader>());

            _diContainer.AddNewObjectAndInit(new UIFactory());
            _diContainer.AddNewObjectAndInit(CreateAsGameObject<UIService>());

            ISceneLoader sceneLoader = CreateAsGameObject<SceneLoader>();
            _diContainer.AddNewObjectAndInit(sceneLoader);
            _diContainer.AddNewObjectAndInit(_sceneManager);
        }
    }
}
