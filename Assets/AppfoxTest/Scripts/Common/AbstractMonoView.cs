using UnityEngine;

namespace AppFoxTest
{
    public abstract class AbstractMonoView : MonoBehaviour, IView, IInjectable, IInitializable
    {
        protected GlobalEventBus _globalEventBus;
        
        public virtual void Inject(DIContainer container)
        {
            _globalEventBus = container.GetSingle<GlobalEventBus>();
            
        }
        public void Init()
        {
            _globalEventBus.OnCreateView(this);
        }

        public abstract void SetPresenter(IPresenter presenter);
    }
}