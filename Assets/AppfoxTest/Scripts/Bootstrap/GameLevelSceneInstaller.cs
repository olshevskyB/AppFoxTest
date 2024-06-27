using UnityEngine;

namespace AppFoxTest
{
    public class GameLevelSceneInstaller : SceneInstaller
    {
        [SerializeField] private LevelsConfig _levelsConfig;

        public override void Init()
        {
            _diContainer.AddNewObjectAndInit(new SceneEventBus());
            _diContainer.AddNewObjectAndInit(_levelsConfig);

            _diContainer.AddNewObjectAndInit(CreateAsGameObject<PrefabLoader>());

            _diContainer.AddNewObjectAndInit(CreateAsGameObject<LevelService>());
            _diContainer.AddNewObjectAndInit(CreateAsGameObject<InputService>());
        }
    }
}
