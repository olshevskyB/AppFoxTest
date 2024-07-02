namespace AppFoxTest
{
    public abstract class AbstractScreenView : AbstractMonoView, IView
    {
        protected IPresenter _presenter;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }

        public virtual void Open()
        {
            gameObject.SetActive(true);
        }

        public override void SetPresenter(IPresenter presenter)
        {
            _presenter = presenter;
        }
    }
}
