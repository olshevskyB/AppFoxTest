﻿using UnityEngine;

namespace AppFoxTest
{
    public abstract class AbstractMonoView : MonoBehaviour, IView, IInjectable
    {
        protected GlobalEventBus _globalEventBus;
        protected UIService _uiService;

        protected IPresenter _presenter;
        
        public virtual void Inject(DIContainer container)
        {
            _globalEventBus = container.GetSingle<GlobalEventBus>();
            _uiService = container.GetSingle<UIService>();
        }

        public virtual void SetPresenter(IPresenter presenter) 
        {
            _presenter = presenter;
        }

        public virtual void UnbindPresenter()
        {
            _presenter = default;
        }
    }
}