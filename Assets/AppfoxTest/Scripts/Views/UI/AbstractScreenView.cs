using UnityEngine;

namespace AppFoxTest
{
    public abstract class AbstractScreenView : AbstractMonoView, IView
    {
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
    }
}
