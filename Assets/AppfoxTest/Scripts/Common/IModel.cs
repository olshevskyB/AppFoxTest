namespace AppFoxTest
{
    public interface IModel
    {
        public void AddPresenter(IPresenter presenter);

        public void OnAddNewView(IView view);

        public void OnUnloadView(IView view);      

        public string GetLogText();
    }
}
