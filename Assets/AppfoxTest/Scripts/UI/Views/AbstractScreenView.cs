using UnityEngine;

namespace AppFoxTest
{
    public abstract class AbstractScreenView : MonoBehaviour, IView
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
        

        public void SetPresenter(IPresenter presenter)
        {
            _presenter = presenter;
        }
    }
}
