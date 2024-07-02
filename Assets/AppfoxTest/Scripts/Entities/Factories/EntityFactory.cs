using UnityEngine;

namespace AppFoxTest
{
    public class EntityFactory : IInjectable, IEntityFactory
    {
        private SceneEventBus _sceneEvents;
        private IPrefabLoader _prefabLoader;
        private GlobalEventBus _globalEventBus;

        private int _iteration = 0;

        public void Inject(DIContainer container)
        {
            _sceneEvents = container.GetSingle<SceneEventBus>();
            _prefabLoader = container.GetSingle<IPrefabLoader>();
            _globalEventBus = container.GetSingle<GlobalEventBus>();
        }

        public IEntityView CreateEntityAtSpawnPoint(Transform parent, SpawnPoint spawnPoint, IUnloader unloader)
        {
            if (spawnPoint.TrySelectEntity(out EntitySO entity))
            {
                EntityModel entityModel = new EntityModel(entity, _iteration);
                _globalEventBus.OnCreateNewModel(entityModel);

                IControlEntityView loadedEntity = _prefabLoader.Load(entity.EntityPrefab, unloader);
                loadedEntity.ID = _iteration;
                loadedEntity.SetParent(parent.transform);
                loadedEntity.SetPositionAndRotation(spawnPoint.transform.position, spawnPoint.transform.rotation);
                loadedEntity.Init();

                _sceneEvents.OnEntitySpawn?.Invoke(loadedEntity);
                _iteration++;
                return loadedEntity;
            }           
            return null;
        }      
    }
}
