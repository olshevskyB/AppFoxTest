namespace AppFoxTest
{
    public class MainMenuModel : IModel
    {
        private IPresenter _presenter;

        public void AddPresenter(IPresenter presenter)
        {
            _presenter = presenter;
        }
    }
}
