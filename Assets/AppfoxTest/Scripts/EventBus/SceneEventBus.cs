using System;

namespace AppFoxTest
{
    public class SceneEventBus
    {
        public Action<LevelView> OnLevelLoaded;
        public Action<GameObjectSO<LevelView>, float> OnLevelLoadingProgress;
    }
}
