using UnityEngine;
using UnityEngine.UI;

namespace AppFoxTest
{
    public class PauseScreenView : AbstractScreenView
    {
        [SerializeField]
        private Button _restartButton;

        [SerializeField]
        private Button _continueButton;

        private SceneEventBus _sceneEvents;

        public override void Inject(DIContainer container)
        {
            base.Inject(container);
            _sceneEvents = container.GetSingle<SceneEventBus>();
            _restartButton.onClick.AddListener(Restart);
            _continueButton.onClick.AddListener(Continue);
        }

        public override void Open()
        {
            base.Open();         
            ApplicationController.SetPause(true);
        }

        private void Continue()
        {
            ApplicationController.SetPause(false);
            _uiService.OpenScreen<GameScreenView>();
        }

        private void Restart()
        {
            ApplicationController.SetPause(false);
            _sceneEvents.OnInvokeRestart?.Invoke();
        }
    }
}
