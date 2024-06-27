using System;

namespace AppFoxTest
{
    public class GlobalEventBus
    {
        public Action<SceneSO> OnSceneLoaded;
        public Action<SceneSO, float> OnLoadProgress;
    }
}
