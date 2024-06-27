using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppFoxTest
{
    [CreateAssetMenu(menuName = "Configs/LevelsConfig")]
    public class LevelsConfig : ScriptableObject
    {
        public List<LevelSO> Levels;

        public LevelSO FirstLevel => Levels.OrderByDescending(l=>l.Number).FirstOrDefault();

        public PlayerController PlayerController; 
    }
}
