using System;

namespace AppFoxTest
{
    public interface ISceneLoader
    {
        public void LoadScene(SceneSO scene, Action<SceneSO> onLoaded, Action<SceneSO, float> onProgress);
    }
}
