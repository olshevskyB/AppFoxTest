using System.Collections.Generic;
using UnityEngine;

namespace AppFoxTest
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField]
        private List<SpawnPoint> _spawnPoints;

        public IReadOnlyList<SpawnPoint> SpawnPoints => _spawnPoints;
    }
}
