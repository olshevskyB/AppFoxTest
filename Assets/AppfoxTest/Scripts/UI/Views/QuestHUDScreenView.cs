using System.ComponentModel;
using TMPro;
using UnityEngine;

namespace AppFoxTest
{
    public class QuestHUDScreenView : AbstractScreenView, IQuestHUDScreenView
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        private SceneEventBus _sceneEventBus;

        private ModelLocator _modelLocator;

        public override void Inject(DIContainer container)
        {
            base.Inject(container);
            _modelLocator = container.GetSingle<ModelLocator>();
            _sceneEventBus = container.GetSingle<SceneEventBus>();
            AddListeners();
        }

        public override void Open()
        {
            base.Open();
            GetModel();
        }

        private void OnDestroy()
        {
            RemoveListeners();
        }

        private void AddListeners()
        {
            _sceneEventBus.OnLevelLoaded += OnLevelLoad;
        }

        private void RemoveListeners()
        {
            _sceneEventBus.OnLevelLoaded -= OnLevelLoad;
        }

        private void OnLevelLoad(LevelView view)
        {
            GetModel();
        }

        private void GetModel()
        {
            IQuestModel model = _modelLocator.GetModel<IQuestModel>();
            model.OnAddNewView(this);
        }

        public void UpdateQuestText(string text)
        {
            _text.text = text;
        }
    }
}
