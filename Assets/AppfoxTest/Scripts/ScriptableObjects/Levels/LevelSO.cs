using UnityEngine;

namespace AppFoxTest
{
    [CreateAssetMenu(menuName = "GameSO/LevelSO")]
    public class LevelSO : GameObjectSO<LevelView>
    {
        [SerializeField] private int _number;
        public int Number => _number;

        [SerializeField] private LevelView _level;
        public LevelView Level => _level;

        public override LevelView Prefab => _level;
    }
}
