using UnityEngine;

namespace AppFoxTest
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawnPoint;
        public Transform PlayerSpawnPoint => _playerSpawnPoint;
    }
}
