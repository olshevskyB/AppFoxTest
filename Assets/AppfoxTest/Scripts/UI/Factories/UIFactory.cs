using System;
using UnityEngine;

namespace AppFoxTest
{
    public class UIFactory : IUIFactory, IInjectable
    {
        private ScreensConfig _screensConfig;
        private IPrefabLoader _loader;
        private IUnloader _unloader;

        private Canvas _instantiatedCanvas;

        public void Inject(DIContainer container)
        {
            _loader = container.GetSingle<IPrefabLoader>();
            _screensConfig = container.GetSingle<ScreensConfig>();
            _unloader = container.GetTransient<IUnloader>();
        }

        public void CreateScreenAsync<T>(Action<T> callback) where T : AbstractScreenView
        {
            ScreenSO prefab = _screensConfig[typeof(T)];
            LoadScreen(callback, prefab);
        }     

        public void CreateStartScreen(Action<AbstractScreenView> callback)
        {
            ScreenSO prefab = _screensConfig.StartScreen;
            LoadScreen(callback, prefab);
        }

        private void LoadScreen<T>(Action<T> callback, ScreenSO prefab) where T : AbstractScreenView
        {
            if (_instantiatedCanvas == null)
            {
                _instantiatedCanvas = _loader.Load(_screensConfig.CanvasPrefab, _unloader);
            }

            _loader.LoadAsync(prefab, _unloader, (screen) =>
            {
                T newScreen = OnScreenLoaded((T)screen);
                callback.Invoke(newScreen);
            });
        }

        private T OnScreenLoaded<T>(T screen) where T : AbstractScreenView
        {
            screen.transform.parent = _instantiatedCanvas.transform;
            return screen;
        }
    }
}
