using UnityEngine;

namespace AppFoxTest
{
    public class LevelService : MonoBehaviour, IInjectable, IInitializable
    {
        private IPrefabLoader _prefabLoader;
        private SceneEventBus _sceneEventBus;
        private GlobalEventBus _globalEventBus;
        private LevelsConfig _levelsConfig;
        private IEntityFactory _entityFactory;
        private IUnloader _unloader;
        private ModelLocator _modeLocator;
        private int _currentLevel;

        public void Inject(DIContainer container)
        {
            _prefabLoader = container.GetSingle<IPrefabLoader>();
            _sceneEventBus = container.GetSingle<SceneEventBus>();
            _globalEventBus = container.GetSingle<GlobalEventBus>();
            _levelsConfig = container.GetSingle<LevelsConfig>();
            _unloader = container.GetTransient<IUnloader>();
            _entityFactory = container.GetSingle<IEntityFactory>();
            _modeLocator = container.GetSingle<ModelLocator>();
        }

        public void Init()
        {
            AddListeners();
        }

        public void OnDestroy()
        {
            RemoveListeners();
        }

        private void AddListeners()
        {
            _sceneEventBus.OnInvokeLevel += LoadLevel;
            _sceneEventBus.OnInvokeNextLevel += LoadNextLevel;
            _globalEventBus.OnInvokeStartGame += OnInvokeStartGame;
        }

        private void RemoveListeners()
        {
            _sceneEventBus.OnInvokeLevel -= LoadLevel;
            _sceneEventBus.OnInvokeNextLevel -= LoadNextLevel;
            _globalEventBus.OnInvokeStartGame -= OnInvokeStartGame;
        }

        private void OnInvokeStartGame()
        {
            LoadLevel(0);
        }

        private void OnProgress(GameObjectSO<LevelView> so, float progress)
        {
            _sceneEventBus.OnLevelLoadingProgress?.Invoke(so, progress);
        }

        private void OnLoaded(LevelView level)
        {
            SetupLevel(level);
            _sceneEventBus.OnLevelLoaded?.Invoke(level);
            _globalEventBus.OnCompleteLoading?.Invoke();
        }

        private void SetupLevel(LevelView level)
        {
            foreach (SpawnPoint spawnPoint in level.SpawnPoints)
            {
                _entityFactory.CreateEntityAtSpawnPoint(transform, spawnPoint, _unloader);
            }
        }

        private void LoadNextLevel()
        {
            _currentLevel++;
            if (_currentLevel >= _levelsConfig.Levels.Count)
            {
                _currentLevel = 0;
            }
            LoadLevel(_currentLevel);
        }

        private void LoadLevel(int level)
        {
            _unloader.Unload();
            _modeLocator.DeleteLevelContextModels();
            _prefabLoader.LoadAsync(_levelsConfig.Levels[level], _unloader, OnLoaded, OnProgress);
            _globalEventBus.OnStartLoading?.Invoke();
            _currentLevel = level;
        }
    }
}