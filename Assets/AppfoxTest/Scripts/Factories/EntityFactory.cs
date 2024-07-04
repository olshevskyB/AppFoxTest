using UnityEngine;

namespace AppFoxTest
{
    public class EntityFactory : IInjectable, IEntityFactory
    {
        private SceneEventBus _sceneEvents;
        private IPrefabLoader _prefabLoader;
        private GlobalEventBus _globalEventBus;
        private DIContainer _diContainer;

        private int _iteration = 0;

        public void Inject(DIContainer container)
        {
            _sceneEvents = container.GetSingle<SceneEventBus>();
            _prefabLoader = container.GetSingle<IPrefabLoader>();
            _globalEventBus = container.GetSingle<GlobalEventBus>();
            _diContainer = container;
        }
        
        public IEntityView CreateEntityAtSpawnPoint(Transform parent, SpawnPoint spawnPoint, IUnloader unloader)
        {
            if (spawnPoint.TrySelectEntity(out EntitySO entity))
            {
                IEntityModel entityModel = entity.EntityPrefab is IPlayerEntityView ? new PlayerEntityModel(entity, _iteration) : new EntityModel(entity, _iteration);
                if (entityModel is IInjectable injectable)
                {
                    injectable.Inject(_diContainer);
                }

                _globalEventBus.OnCreateNewModel(entityModel);
                IControlEntityView loadedEntity = _prefabLoader.Load(entity.EntityPrefab, unloader);
                loadedEntity.ID = _iteration;
                loadedEntity.SetParent(parent.transform);
                loadedEntity.SetPositionAndRotation(spawnPoint.transform.position, spawnPoint.transform.rotation);
                loadedEntity.StartPosition = spawnPoint.transform;
                //При создании новой вида, обязательно нужно оповестить об этом модель, подробнее смотреть в MainInstaller
                entityModel.AddView(loadedEntity);

                _sceneEvents.OnEntitySpawn?.Invoke(loadedEntity);
                _iteration++;
                return loadedEntity;
            }           
            return null;
        }      
    }
}
