using System;
using UnityEngine;
using UnityEngine.UI;

namespace AppFoxTest
{
    public class LoseScreenView : AbstractScreenView
    {
        [SerializeField]
        private Button _restartButton;

        private SceneEventBus _sceneEventBus;

        public override void Inject(DIContainer container)
        {
            base.Inject(container);
            _restartButton.onClick.AddListener(Restart);
            _sceneEventBus = container.GetSingle<SceneEventBus>();
        }

        private void Restart()
        {
            _sceneEventBus.OnInvokeRestart?.Invoke();
        }
    }
}
