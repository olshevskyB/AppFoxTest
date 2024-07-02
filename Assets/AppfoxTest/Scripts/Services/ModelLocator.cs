using System.Collections.Generic;
using UnityEngine;

namespace AppFoxTest
{
    public class ModelLocator : MonoBehaviour, IInjectable, IInitializable
    {
        private GlobalEventBus _eventBus;

        private List<IModel> _models = new List<IModel>();

        public void Inject(DIContainer container)
        {
            _eventBus = container.GetSingle<GlobalEventBus>();
            _eventBus.OnCreateView += OnCreateNewView;
            _eventBus.OnCreateNewModel += OnCreateNewModel;
        }
        private float delayLog; 
        public void Update()
        {           
            if (delayLog <= 0f)
            {
                foreach (IModel model in _models)
                {
                    Debug.Log(model.GetLogText());
                }
                delayLog = 1f;
            }
            else
            {
                delayLog -= Time.deltaTime;
            }           
        }

        public void Init()
        {
            _models.Add(new MainMenuModel());
        }

        public void AddModel(IModel model)
        {
            _models.Add(model);
        }

        private void OnCreateNewModel(IModel model)
        {
            _models.Add(model);
        }

        private void OnCreateNewView(IView view)
        {
            _models.ForEach(m => m.TrySubscribeView(view));
        }
    }
}
