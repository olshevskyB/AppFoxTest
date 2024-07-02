namespace AppFoxTest
{
    public class MainMenuModel : IModel
    {
        private IPresenter _presenter;

        public void AddPresenter(IPresenter presenter)
        {
            _presenter = presenter;
        }

        public void TrySubscribeView(IView view)
        {
            if (view is MainMenuScreenView mainMenuScreenView)
            {
                new MainMenuPresenter(mainMenuScreenView, this);
            }
        }
    }
}
