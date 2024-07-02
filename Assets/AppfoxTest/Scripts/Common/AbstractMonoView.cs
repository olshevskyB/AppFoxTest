using UnityEngine;

namespace AppFoxTest
{
    public abstract class AbstractMonoView : MonoBehaviour, IView, IInjectable, IInitializable
    {
        protected GlobalEventBus _globalEventBus;
        protected UIService _uiService;
        
        public virtual void Inject(DIContainer container)
        {
            _globalEventBus = container.GetSingle<GlobalEventBus>();
            _uiService = container.GetSingle<UIService>();
        }
        public void Init()
        {
            _globalEventBus.OnCreateView(this);
        }

        public abstract void SetPresenter(IPresenter presenter);
    }
}