namespace AppFoxTest
{
    public class WinScreenModel : IModel
    {
        IPresenter _presenter;

        public void AddPresenter(IPresenter presenter)
        {
            if (presenter is WinScreenPresenter screenPresenter)
            {
                _presenter = screenPresenter;
            }
        }

        public void AddView(IView view)
        {
            if (view is WinScreenView winScreen)
            {
                new WinScreenPresenter(winScreen, this);
            }
        }

        public void OnUnloadView(IView view)
        {
            if (view is WinScreenView winScreen)
            {
                _presenter = null;
            }
        }
    }
}
