using UnityEngine;

namespace AppFoxTest
{
    [CreateAssetMenu(menuName = "GameSO/LevelSO")]
    public class LevelSO : GameObjectSO<GameLevel>
    {
        [SerializeField] private int _number;
        public int Number => _number;

        [SerializeField] private GameLevel _level;
        public GameLevel Level => _level;

        public override GameLevel Prefab => _level;
    }
}
