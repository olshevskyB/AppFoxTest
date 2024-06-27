using UnityEngine;

namespace AppFoxTest
{
    [RequireComponent(typeof(Collider))]
    public class NextLevelCube : MonoBehaviour
    {
        [SerializeField] private LevelSO _levelSO;

        public LevelSO LevelSO => _levelSO;
    }
}