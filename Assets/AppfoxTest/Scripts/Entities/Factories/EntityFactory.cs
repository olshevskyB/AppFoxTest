using UnityEngine;

namespace AppFoxTest
{
    public class EntityFactory : IInjectable, IEntityFactory
    {
        private SceneEventBus _sceneEvents;
        private IPrefabLoader _prefabLoader;

        public void Inject(DIContainer container)
        {
            _sceneEvents = container.GetSingle<SceneEventBus>();
            _prefabLoader = container.GetSingle<IPrefabLoader>();
        }

        public IEntityView CreateEntityAtSpawnPoint(Transform parent, SpawnPoint spawnPoint, IUnloader unloader)
        {
            if (spawnPoint.TrySelectEntity(out EntitySO entity))
            {
                EntityModel entityModel = new EntityModel(entity); 

                IEntityView loadedEntity = _prefabLoader.Load(entity.EntityPrefab, unloader);
                loadedEntity.SetParent(parent.transform);
                loadedEntity.SetPositionAndRotation(spawnPoint.transform.position, spawnPoint.transform.rotation);

                IPresenter presenter = new GameEntityPresenter(loadedEntity, entityModel);
                presenter.UpdateAllValues();

                _sceneEvents.OnEntitySpawn?.Invoke(loadedEntity);            
                return loadedEntity;
            }           
            return null;
        }      
    }
}
