using System;
using UnityEngine;
using UnityEngine.UI;

namespace AppFoxTest
{
    public class MainMenuScreenView : AbstractScreenView
    {
        [SerializeField]
        private Button _startButton;
        private MainMenuPresenter _menuPresenter;
        private SceneEventBus _sceneEvent;

        public override void Inject(DIContainer container)
        {
            base.Inject(container);
            _sceneEvent = container.GetSingle<SceneEventBus>();
            AddListener();
        }

        private void OnDestroy()
        {
            RemoveListener();
        }

        private void AddListener()
        {
            _sceneEvent.OnLevelLoaded += OnLevelLoaded;
        }     

        private void RemoveListener()
        {
            _sceneEvent.OnLevelLoaded -= OnLevelLoaded;
        }

        private void OnLevelLoaded(LevelView view)
        {
            if (gameObject.activeSelf)
            {
                _uiService.OpenScreen<GameScreenView>();
            }
        }

        private void Awake()
        {
            _startButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            _globalEventBus.OnInvokeStartGame?.Invoke();
        }
    }
}
