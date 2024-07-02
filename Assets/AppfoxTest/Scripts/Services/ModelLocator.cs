using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppFoxTest
{
    public class ModelLocator : MonoBehaviour, IInjectable, IInitializable
    {
        private GlobalEventBus _eventBus;

        private List<IModel> _models = new List<IModel>();

        public IReadOnlyList<IModel> Models => _models;

        public void Inject(DIContainer container)
        {
            _eventBus = container.GetSingle<GlobalEventBus>();
            _eventBus.OnCreateView += OnCreateNewView;
            _eventBus.OnCreateNewModel += OnCreateNewModel;
        }

        public void Init()
        {
            _models.Add(new MainMenuModel());
        }

        public T GetModel<T>() where T : IModel
        {
            return _models.OfType<T>().FirstOrDefault();
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
            _models.ForEach(m => m.OnAddNewView(view));
        }
    }
}
