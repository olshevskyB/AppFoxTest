using UnityEngine;

namespace AppFoxTest
{
    public class CameraService : MonoBehaviour, IInitializable, IInjectable
    {
        private CameraConfig _cameraConfig;
        private PrefabLoader _prefabLoader;
        private IUnloader _unloader;
        private SceneEventBus _sceneEventBus;

        private CameraController _cameraController;

        public void Inject(DIContainer container)
        {
            _cameraConfig = container.GetSingle<CameraConfig>();
            _prefabLoader = container.GetSingle<PrefabLoader>();
            _unloader = container.GetTransient<IUnloader>();
            _sceneEventBus = container.GetSingle<SceneEventBus>();
        }

        public void Init()
        {
            _cameraController = _prefabLoader.Load(_cameraConfig.CameraPrefab, _unloader);
            AddListeners();
        }

        private void OnDestroy()
        {
            RemoveListeners();
        }

        private void AddListeners()
        {
            _sceneEventBus.OnPlayerSpawn += OnPlayerSpawn;
        }

        private void RemoveListeners()
        {
            _sceneEventBus.OnPlayerSpawn -= OnPlayerSpawn;
        }
        private void OnPlayerSpawn(IControlEntityView controller)
        {
            _cameraController.SetTarget(controller.Transform);
        }
    }
}