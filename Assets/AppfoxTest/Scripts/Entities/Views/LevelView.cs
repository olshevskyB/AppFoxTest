using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppFoxTest
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField]
        private List<SpawnPoint> _spawnPoints;

        [SerializeField]
        private List<AbstractQuest> _quests;

        public IReadOnlyList<AbstractQuest> Quests => _quests;

        public IReadOnlyList<SpawnPoint> SpawnPoints => _spawnPoints;

        public void OnValidate()
        {
            _spawnPoints = GetComponentsInChildren<SpawnPoint>().ToList();
        }
    }
}
