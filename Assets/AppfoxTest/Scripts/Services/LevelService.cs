using System.Drawing;
using UnityEngine;

namespace AppFoxTest
{
    public class LevelService : MonoBehaviour, IInjectable, IInitializable
    {
        private IPrefabLoader _prefabLoader;
        private SceneEventBus _sceneEventBus;
        private LevelsConfig _levelsConfig;

        public void Inject(DIContainer container)
        {
            _prefabLoader = container.GetSingle<IPrefabLoader>();
            _sceneEventBus = container.GetSingle<SceneEventBus>();
            _levelsConfig = container.GetSingle<LevelsConfig>();
        }

        public void Init()
        {
            _prefabLoader.Load(_levelsConfig.FirstLevel, OnLoaded, OnProgress);
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
            PlayerController playerController = _prefabLoader.Load(_levelsConfig.PlayerController);
            SetObjectToPoint(playerController.transform, level.transform, level.PlayerSpawnPoint);
        }

        private void SetObjectToPoint(Transform objectTransform, Transform point, Transform parent)
        {
            objectTransform.transform.parent = parent;
            objectTransform.transform.SetPositionAndRotation(point.position, point.rotation);
        }
    }
}