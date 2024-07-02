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
                OpenScreen(_cachedViews[type]);
            };
            _uiFactory.CreateStartScreen(onLoad, transform);
        }

        public void OpenScreen<T>(bool additive = false) where T : AbstractScreenView
        {
            Type screenType = typeof(T);
            if (!_cachedViews.ContainsKey(screenType))
            {
                Action<T> onLoad = (screen) =>
                {
                    _cachedViews[screenType] = screen;
                    OpenScreen(additive, screen);
                };
                _uiFactory.CreateScreenAsync(onLoad);
            }
            else
            {
                AbstractScreenView screen = _cachedViews[screenType];
                OpenScreen(additive, screen);
            }
        }

        private void OpenScreen(bool additive, AbstractScreenView screenView)
        {
            if (additive)
            {
                OpenScreenAdditive(screenView);
            }
            else
            {
                OpenScreen(screenView);
            }
        }

        private void OpenScreen(AbstractScreenView screenView)
        {
            if (_currentScreen != null)
            {
                _currentScreen.Close();
                _additiveModeActiveScreens.ForEach(s => s.Close());
                _additiveModeActiveScreens.Clear();              
            }
            _currentScreen = screenView;
            _currentScreen.Open();
        }

        private void OpenScreenAdditive(AbstractScreenView screenView)
        {
            screenView.Open();
            _additiveModeActiveScreens.Add(screenView);
        }
    }
}
