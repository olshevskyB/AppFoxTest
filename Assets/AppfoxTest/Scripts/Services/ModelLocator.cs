using System.Collections.Generic;

namespace AppFoxTest
{
    public class ModelLocator : IInjectable, IInitializable
    {
        private GlobalEventBus _eventBus;

        private List<IModel> _models = new List<IModel>();

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
