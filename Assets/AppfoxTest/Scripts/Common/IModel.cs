namespace AppFoxTest
{
    public interface IModel
    {
        public void AddPresenter(IPresenter presenter);

        public void TrySubscribeView(IView view);
    }
}
