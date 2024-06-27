using UnityEngine;
using UnityEngine.SceneManagement;

namespace AppFoxTest
{
    [CreateAssetMenu(menuName = "GameSO/SceneSO")]
    public class SceneSO : ScriptableObject
    {
        public int Index;
        public LoadSceneMode SceneMode;
    }
}
