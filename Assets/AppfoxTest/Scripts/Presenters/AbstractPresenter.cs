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

        public void Unbind()
        {
            _view.UnbindPresenter();
            _view = default;
            _model = default;           
        }

        public abstract void UpdateAllValues();
    }
}
