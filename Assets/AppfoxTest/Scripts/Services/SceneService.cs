using UnityEngine;

namespace AppFoxTest
{
    public class SceneService : MonoBehaviour, ISceneService, IInjectable, IInitializable
    {
        private ISceneLoader _sceneLoader;
        private ScenesConfig _scenesConfig;
        private GlobalEventBus _globalEvents;

        public void Init()
        {
            LoadStartScene();
        }

        public void Inject(DIContainer container)
        {
            _sceneLoader = container.GetSingle<ISceneLoader>();
            _scenesConfig = container.GetSingle<ScenesConfig>();
            _globalEvents = container.GetSingle<GlobalEventBus>();
        }

        private void LoadStartScene()
        {
            _sceneLoader.LoadScene(_scenesConfig.StartScene, OnLoadedScene, OnLoadProgress);
        }

        private void OnLoadedScene(SceneSO sceneSO)
        {
            _globalEvents.OnSceneLoaded?.Invoke(sceneSO);
        }

        private void OnLoadProgress(SceneSO sceneSO, float value)
        {
            _globalEvents.OnLoadProgress?.Invoke(sceneSO, value);
        }
    }
}
