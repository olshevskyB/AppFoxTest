using System;
using System.Collections.Generic;
using UnityEngine;

namespace AppFoxTest
{
    public class UIService : MonoBehaviour, IInjectable, IInitializable
    {
        [SerializeField]
        private IUIFactory _uiFactory;

        private Dictionary<Type, AbstractScreenView> _cachedViews = new Dictionary<Type, AbstractScreenView>();
        private AbstractScreenView _currentScreen;

        private List<AbstractScreenView> _additiveModeActiveScreens = new List<AbstractScreenView>();

        public void Inject(DIContainer container)
        {
            _uiFactory = container.GetSingle<IUIFactory>();
        }

        public void Init()
        {
            Action<AbstractScreenView> onLoad = (screen) =>
            {
                Type type = screen.GetType();
                _cachedViews[type] = screen;
                OnLoadScreen(_cachedViews[type]);
            };
            _uiFactory.CreateStartScreen(onLoad);
        }
        
        public void OpenScreen<T>(bool additive) where T : AbstractScreenView
        {
            Type screenType = typeof(T);
            if (!_cachedViews.ContainsKey(screenType))
            {
                Action<T> onLoad = (screen) =>
                {
                    _cachedViews[screenType] = screen;
                    if (additive)
                    {
                        OnLoadScreen(_cachedViews[screenType]);
                    }
                    else
                    {
                        OnLoadScreenAdditive(_cachedViews[screenType]);
                    }
                };
                _uiFactory.CreateScreenAsync(onLoad);
            }
        }
        private void OnLoadScreen(AbstractScreenView screenView)
        {
            if (_currentScreen != null)
            {
                _currentScreen.Close();
                _additiveModeActiveScreens.ForEach(s => s.Close());
                _additiveModeActiveScreens.Clear();
                _currentScreen = screenView;
            }
        }

        private void OnLoadScreenAdditive(AbstractScreenView screenView)
        {
            screenView.Open();
            _additiveModeActiveScreens.Add(screenView);
        }
    }
}
