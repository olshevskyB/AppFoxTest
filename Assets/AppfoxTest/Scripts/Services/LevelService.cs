﻿using UnityEngine;

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

        public void Inject(DIContainer container)
        {
            _prefabLoader = container.GetSingle<IPrefabLoader>();
            _sceneEventBus = container.GetSingle<SceneEventBus>();
            _globalEventBus = container.GetSingle<GlobalEventBus>();
            _levelsConfig = container.GetSingle<LevelsConfig>();
            _unloader = container.GetTransient<IUnloader>();
            _entityFactory = container.GetSingle<IEntityFactory>();
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
            _sceneEventBus.OnInvokeNextLevel += LoadLevel;
            _globalEventBus.OnInvokeStartGame += OnInvokeStartGame;
        }

        private void RemoveListeners()
        {
            _sceneEventBus.OnInvokeNextLevel -= LoadLevel;
            _globalEventBus.OnInvokeStartGame -= OnInvokeStartGame;
        }

        private void OnInvokeStartGame()
        {
            LoadLevel(_levelsConfig.FirstLevel);
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
            foreach (SpawnPoint spawnPoint in level.SpawnPoints)
            {
                _entityFactory.CreateEntityAtSpawnPoint(transform, spawnPoint, _unloader);
            }
        }

        private void LoadLevel(LevelSO level)
        {
            _unloader.Unload();
            _prefabLoader.LoadAsync(level, _unloader, OnLoaded, OnProgress);
        }
    }
}