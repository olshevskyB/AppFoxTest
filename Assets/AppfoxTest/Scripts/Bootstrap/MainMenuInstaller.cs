using UnityEngine;

namespace AppFoxTest
{
    public class MainMenuInstaller : SceneInstaller
    {
        public override void Init()
        {
            Debug.Log("Test " + _diContainer);
        }
    }
}
