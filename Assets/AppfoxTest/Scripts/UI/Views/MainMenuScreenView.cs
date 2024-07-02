using UnityEngine;
using UnityEngine.UI;

namespace AppFoxTest
{
    public class MainMenuScreenView : AbstractScreenView
    {
        [SerializeField]
        private Button _startButton;
        private MainMenuPresenter _menuPresenter;

        public override void Inject(DIContainer container)
        {
            base.Inject(container);
        }

        public override void SetPresenter(IPresenter presenter)
        {
            if (presenter is MainMenuPresenter menuPresenter)
            {
                _menuPresenter = menuPresenter;
            }
            else
            {
                Debug.LogError($"The presenter {presenter} is not an MainMenuPresenter!");
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
