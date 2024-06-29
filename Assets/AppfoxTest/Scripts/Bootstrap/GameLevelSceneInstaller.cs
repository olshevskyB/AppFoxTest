using UnityEngine;

namespace AppFoxTest
{
    public class GameLevelSceneInstaller : SceneInstaller
    {
        [SerializeField] private LevelsConfig _levelsConfig;
        [SerializeField] private CameraConfig _cameraConfig;

        public override void Init()
        {
            _diContainer.AddNewObjectAndInit(_cameraConfig);
            _diContainer.AddNewObjectAndInit(_levelsConfig);

            _diContainer.AddNewObjectAndInit(new SceneEventBus());     
            
            _diContainer.AddNewObjectAndInit(new Unloader());
            _diContainer.AddNewObjectAndInit(CreateAsGameObject<PrefabLoader>());
            _diContainer.AddNewObjectAndInit(new EntityFactory());
         
            _diContainer.AddNewObjectAndInit(CreateAsGameObject<CameraService>());
            _diContainer.AddNewObjectAndInit(CreateAsGameObject<LevelService>());
            _diContainer.AddNewObjectAndInit(CreateAsGameObject<InputService>());
        }
    }
}
