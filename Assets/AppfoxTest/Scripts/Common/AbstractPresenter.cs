namespace AppFoxTest
{
    public abstract class AbstractPresenter<TView, TModel> : IPresenter where TView : IView where TModel : IModel
    {
        protected TView _view;
        protected TModel _model;

        public AbstractPresenter(TView view, TModel model)
        {
            _view = view;
            _view.SetPresenter(this);

            _model = model;
            _model.AddPresenter(this);

            UpdateAllValues();
        }

        public abstract void UpdateAllValues();
    }
}
