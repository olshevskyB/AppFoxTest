namespace AppFoxTest
{
    public abstract class AbstractScreenPresenter<TView, TModel> : AbstractPresenter<TView, TModel> where TView : IView where TModel : IModel
    {
        protected AbstractScreenPresenter(TView view, TModel model) : base(view, model)
        {

        }
    }
}
