using System;

namespace AppFoxTest
{
    public class GlobalEventBus
    {
        public Action<SceneSO> OnSceneLoaded;
        public Action<SceneSO, float> OnLoadProgress;
        public Action<SceneEventBus> OnSceneEventBusInit;

        public Action OnStartLoading;
        public Action OnStartGame;

        public Action<IView> OnCreateView;
        public Action<IModel> OnCreateNewModel;
    }
}
