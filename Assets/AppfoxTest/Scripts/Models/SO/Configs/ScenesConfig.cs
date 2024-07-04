using System.Collections.Generic;
using UnityEngine;

namespace AppFoxTest
{
    [CreateAssetMenu(menuName = "Configs/ScenesConfig")]
    public class ScenesConfig : ScriptableObject
    {
        public List<SceneSO> Scenes;
        public SceneSO StartScene;
    }
}
