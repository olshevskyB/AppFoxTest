using System;

namespace AppFoxTest
{
    public class GlobalEventBus
    {
        public Action<SceneSO> OnSceneLoaded;
        public Action<SceneSO, float> OnLoadProgress;
        public Action<SceneEventBus> OnSceneEventBusInit;

        public Action OnStartLoading;
        public Action OnInvokeStartGame;

        public Action<IView> OnCreateView;
        public Action<IModel> OnCreateNewModel;
        public Action<IEntityView> OnUnloadEntity;
    }
}
