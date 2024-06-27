using UnityEngine;

namespace AppFoxTest
{
    public class LevelService : MonoBehaviour, IInjectable, IInitializable
    {
        private IPrefabLoader _prefabLoader;
        private SceneEventBus _sceneEventBus;
        private LevelsConfig _levelsConfig;

        public void Init()
        {
            _prefabLoader.Load(_levelsConfig.FirstLevel, OnLoaded, OnProgress);
        }

        private void OnProgress(GameObjectSO<LevelView> so, float progress)
        {
            _sceneEventBus.OnLevelLoadingProgress.Invoke(so, progress);
        }

        private void OnLoaded(LevelView view)
        {
            _sceneEventBus.OnLevelLoaded.Invoke(view);
        }

        public void Inject(DIContainer container)
        {
            _prefabLoader = container.GetSingle<IPrefabLoader>();
            _sceneEventBus = container.GetSingle<SceneEventBus>();
            _levelsConfig = container.GetSingle<LevelsConfig>();
        }
    }
}