using UnityEngine;

namespace AppFoxTest
{
    public class LevelService : MonoBehaviour, IInjectable, IInitializable
    {
        private IPrefabLoader _prefabLoader;
        private SceneEventBus _sceneEventBus;
        private LevelsConfig _levelsConfig;
        private IUnloader _unloader;

        public void Inject(DIContainer container)
        {
            _prefabLoader = container.GetSingle<IPrefabLoader>();
            _sceneEventBus = container.GetSingle<SceneEventBus>();
            _levelsConfig = container.GetSingle<LevelsConfig>();
            _unloader = container.GetSingle<IUnloader>();
        }

        public void Init()
        {
            _sceneEventBus.OnInvokeNextLevel += LoadLevel;
            LoadLevel(_levelsConfig.FirstLevel);
        }

        private void OnDestroy()
        {
            _sceneEventBus.OnInvokeNextLevel -= LoadLevel;
        }

        private void OnProgress(GameObjectSO<LevelView> so, float progress)
        {
            _sceneEventBus.OnLevelLoadingProgress?.Invoke(so, progress);
        }

        private void OnLoaded(LevelView level)
        {
            SetupLevel(level);
            _sceneEventBus.OnLevelLoaded?.Invoke(level);
        }

        private void SetupLevel(LevelView level)
        {
            PlayerController playerController = _prefabLoader.Load(_levelsConfig.PlayerController, _unloader);
            SetObjectToPoint(playerController.transform, level.transform, level.PlayerSpawnPoint);
        }

        private void SetObjectToPoint(Transform objectTransform, Transform point, Transform parent)
        {
            objectTransform.transform.parent = parent;
            objectTransform.transform.SetPositionAndRotation(point.position, point.rotation);
        }

        private void LoadLevel(LevelSO level)
        {
            _unloader.Unload();
            _prefabLoader.Load(level, _unloader, OnLoaded, OnProgress);
        }
    }
}