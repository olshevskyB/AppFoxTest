namespace AppFoxTest
{
    public class GameScreenModel : IModel
    {
        private IPresenter _presenter;

        public void AddPresenter(IPresenter presenter)
        {
            _presenter = presenter;
        }

        public string GetLogText()
        {
            return nameof(GameScreenModel);
        }

        public void AddView(IView view)
        {
            if (view is GameScreenView gameView)
            {
                new GameScreenPresenter(gameView, this);
            }
        }

        public void OnUnloadView(IView view)
        {
            if (view is GameScreenView screenPresenter)
            {
                _presenter = null;
            }
        }
    }
}