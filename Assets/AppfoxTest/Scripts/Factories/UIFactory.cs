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

        public void CreateStartScreen(Action<AbstractScreenView> callback, Transform parent)
        {
            _instantiatedCanvas = _loader.Load(_screensConfig.CanvasPrefab, _unloader);
            _instantiatedCanvas.transform.SetParent(parent);

            LoadScreen(callback, _screensConfig.StartScreen);
        }

        private void LoadScreen<T>(Action<T> callback, ScreenSO prefab) where T : AbstractScreenView
        {
            AbstractScreenView screenView = _loader.Load(prefab.Prefab, _unloader, _instantiatedCanvas.transform);
            callback.Invoke(screenView as T);
        }

        private void LoadScreenAsync<T>(Action<T> callback, ScreenSO prefab) where T : AbstractScreenView
        {
            //InstantiateAsync ломает RectTransform https://forum.unity.com/threads/object-instantiateasync-not-working-with-ui-prefabs.1551740/
            _loader.LoadAsync(prefab, _unloader, (screen) =>
            {
                T newScreen = OnScreenLoaded((T)screen);
                callback.Invoke(newScreen);
            }, null, _instantiatedCanvas.transform);
        }

        private T OnScreenLoaded<T>(T screen) where T : AbstractScreenView
        {
            return screen;
        }
    }
}
