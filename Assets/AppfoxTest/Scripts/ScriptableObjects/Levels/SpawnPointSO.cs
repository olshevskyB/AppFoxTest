using System.Collections.Generic;
using UnityEngine;

namespace AppFoxTest
{
    [CreateAssetMenu(menuName = "GameSO/SpawnPointSO", fileName = "SpawnPointSO")]
    public class SpawnPointSO : ScriptableObject
    {
        [SerializeField]
        private List<EntitySO> _entitiesForSpawn;

        public IReadOnlyList<EntitySO> EntitiesForSpawn => _entitiesForSpawn;

        [SerializeField]
        private bool _isPlayerSpawner;

        public bool IsPlayerSpawn => _isPlayerSpawner;     
    }
}