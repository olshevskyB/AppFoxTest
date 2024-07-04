namespace AppFoxTest
{
    public interface IModel
    {
        public void AddPresenter(IPresenter presenter);

        public void AddView(IView view);

        public void OnUnloadView(IView view);      
    }
}
