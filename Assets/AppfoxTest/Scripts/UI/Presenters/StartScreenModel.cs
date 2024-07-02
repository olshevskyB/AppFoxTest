namespace AppFoxTest
{
    public class StartScreenModel : IModel
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

        public void OnAddNewView(IView view)
        {
            if (view is StartScreenView startScreen)
            {
                new StartScreenPresenter(startScreen, this);
            }
        }

        public void OnUnloadView(IView view)
        {
            if (view is StartScreenView screenPresenter)
            {
                _presenter = null;
            }
        }
    }
}