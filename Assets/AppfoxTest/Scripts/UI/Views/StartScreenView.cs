using System;

namespace AppFoxTest
{
    public class StartScreenView : AbstractScreenView
    {
        public override void Inject(DIContainer container)
        {
            base.Inject(container);
            AddListener();
        }

        private void OnDestroy()
        {
            RemoveListener();
        }

        private void AddListener()
        {
            _globalEventBus.OnSceneLoaded += OnSceneLoaded;
        }
        
        private void RemoveListener()
        {
            _globalEventBus.OnSceneLoaded -= OnSceneLoaded;
        }
        private void OnSceneLoaded(SceneSO sO)
        {
            _uiService.OpenScreen<MainMenuScreenView>(false);
        }

        public override void SetPresenter(IPresenter presenter)
        {

        }
    }
}
