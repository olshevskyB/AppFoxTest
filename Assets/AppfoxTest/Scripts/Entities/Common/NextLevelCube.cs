using UnityEngine;

namespace AppFoxTest
{
    [RequireComponent(typeof(Collider))]
    public class NextLevelCube : MonoBehaviour
    {
        [SerializeField] private int _level;

        public int Level => _level;
    }
}