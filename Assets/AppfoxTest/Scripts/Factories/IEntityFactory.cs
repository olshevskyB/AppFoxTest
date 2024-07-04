using UnityEngine;

namespace AppFoxTest
{
    public interface IEntityFactory
    {
        public IEntityView CreateEntityAtSpawnPoint(Transform parent, SpawnPoint spawnPoint, IUnloader unloader);
    }
}
