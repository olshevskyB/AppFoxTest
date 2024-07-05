using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppFoxTest
{
    public class ModelLocator : MonoBehaviour, IInjectable
    {
        private GlobalEventBus _eventBus;

        private List<IModel> _models = new List<IModel>();

        private List<IUpdateModel> _updateModels = new List<IUpdateModel>();

        public IReadOnlyList<IModel> Models => _models;

        public void Inject(DIContainer container)
        {
            _eventBus = container.GetSingle<GlobalEventBus>();
            _eventBus.OnCreateNewModel += OnCreateNewModel;
        }

        public void Update()
        {
            _updateModels.ForEach(m => m.Update(Time.deltaTime));
        }

        public void DeleteLevelContextModels()
        {
            List<ILevelContextModel> _modelsForDelete = _models.OfType<ILevelContextModel>().ToList();
            _modelsForDelete.ForEach(m =>
            {
                m.Delete();
                RemoveModel(m);
            });
        }

        public T GetModel<T>() where T : IModel
        {
            return _models.OfType<T>().FirstOrDefault();
        }

        public void RemoveModel(IModel model)
        {
            _models.Remove(model);
            UpdatesModelsLists();
        }

        public void AddModel(IModel model)
        {
            _models.Add(model);
            UpdatesModelsLists();
        }

        private void OnCreateNewModel(IModel model)
        {
            _models.Add(model);
            UpdatesModelsLists();
        }

        private void UpdatesModelsLists()
        {
            _updateModels = _models.OfType<IUpdateModel>().ToList();
        }
    }
}
