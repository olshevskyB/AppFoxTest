namespace AppFoxTest
{
    public class MainMenuModel : IModel
    {
        private IPresenter _presenter;

        public void AddPresenter(IPresenter presenter)
        {
            _presenter = presenter;
        }

        public string GetLogText()
        {
            return nameof(MainMenuModel);
        }

        public void AddView(IView view)
        {
            if (view is MainMenuScreenView mainMenuScreenView)
            {
                new MainMenuPresenter(mainMenuScreenView, this);
            }
        }

        public void OnUnloadView(IView view)
        {
            if (view is MainMenuScreenView mainMenuScreenView)
            {
                _presenter = null;
            }
        }
    }
}
