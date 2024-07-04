using UnityEngine;

namespace AppFoxTest
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField]
        private SpawnPointSO _spawnPointSO;

        [SerializeField]
        private GameObject _view;

        public SpawnPointSO SpawnPointSO => _spawnPointSO;

        private void Awake()
        {
            Hide();
        }

        public bool TrySelectEntity(out EntitySO entity)
        {
            if (_spawnPointSO is ChanceSpawnPointSO chanceSpawnPoint)
            {
                if (Random.Range(0f, 1f) < chanceSpawnPoint.SpawnChance)
                {
                    entity = null;
                    return false;
                }
            }
            entity = _spawnPointSO.EntitiesForSpawn[Random.Range(0, _spawnPointSO.EntitiesForSpawn.Count)];
            return true;
        }

        public void Hide()
        {
            _view.SetActive(false);
        }
    }
}
