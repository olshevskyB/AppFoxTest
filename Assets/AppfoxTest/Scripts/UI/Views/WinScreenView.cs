using System;
using UnityEngine;
using UnityEngine.UI;

namespace AppFoxTest
{
    public class WinScreenView : AbstractScreenView
    {
        [SerializeField]
        private Button _nextLevelButton;

        private SceneEventBus _sceneEvents;

        public override void Inject(DIContainer container)
        {
            base.Inject(container);
            _sceneEvents = container.GetSingle<SceneEventBus>();
        }

        private void Start()
        {
            _nextLevelButton.onClick.AddListener(NextLevel);
        }

        private void NextLevel()
        {
            _sceneEvents?.OnInvokeNextLevel();
        }   
    }
}
