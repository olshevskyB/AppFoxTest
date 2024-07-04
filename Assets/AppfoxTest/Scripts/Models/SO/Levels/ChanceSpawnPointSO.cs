using UnityEngine;

namespace AppFoxTest
{
    [CreateAssetMenu(menuName = "GameSO/ChanceSpawnPointSO", fileName = "ChanceSpawnPointSO")]
    public class ChanceSpawnPointSO : SpawnPointSO
    {
        [SerializeField, Range(0f, 1f)]
        private float _baseSpawnChance;

        public float SpawnChance
        {
            get => _baseSpawnChance;
        }
    }
}
