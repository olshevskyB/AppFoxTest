using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppFoxTest
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField]
        private List<SpawnPoint> _spawnPoints;

        public IReadOnlyList<SpawnPoint> SpawnPoints => _spawnPoints;

        public void OnValidate()
        {
            _spawnPoints = GetComponentsInChildren<SpawnPoint>().ToList();
        }
    }
}
