namespace AppFoxTest
{
    public interface IView
    {
        public void SetPresenter(IPresenter presenter);

        public void UnbindPresenter();
    }
}
