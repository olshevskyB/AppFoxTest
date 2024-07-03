using System.Linq;
using UnityEngine;

namespace AppFoxTest
{
    public class QuestService : MonoBehaviour, IInitializable, IInjectable
    {
        private SceneEventBus _sceneEvent;
        private GlobalEventBus _globalEvent;
        private ModelLocator _modelLocator;

        private IQuestModel _currentModel;

        public void Inject(DIContainer container)
        {
            _sceneEvent = container.GetSingle<SceneEventBus>();
            _globalEvent = container.GetSingle<GlobalEventBus>();
            _modelLocator = container.GetSingle<ModelLocator>();
        }
        public void Init()
        {
            AddListeners();
        }

        private void OnDestroy()
        {
            RemoveListeners();
        }

        private void AddListeners()
        {
            _sceneEvent.OnLevelLoaded += OnLevelLoaded;
            _sceneEvent.OnQuestProgress += OnQuestProgress;
            _sceneEvent.OnQuestComplete += OnQuestComplete;
        }

        private void RemoveListeners()
        {
            _sceneEvent.OnLevelLoaded -= OnLevelLoaded;
            _sceneEvent.OnQuestProgress -= OnQuestProgress;
            _sceneEvent.OnQuestComplete -= OnQuestComplete;
        }

        private void OnLevelLoaded(LevelView view)
        {
            if (_currentModel != null)
            {
                _modelLocator.RemoveModel(_currentModel);
            }
            _currentModel = new QuestsModel(view.Quests.ToList());
            foreach (AbstractQuest quest in _currentModel.Quests)
            {
                quest.SetEvents(_globalEvent, _sceneEvent);
            }
            _modelLocator.AddModel(_currentModel);
        }
        private void OnQuestProgress(AbstractQuest quest)
        {
            _currentModel.ProgressQuest();
        }

        private void OnQuestComplete(AbstractQuest quest)
        {
            _currentModel.AddCompletedQuest(quest);
            if (_currentModel.Quests.Count <= 0)
            {
                _sceneEvent.OnCompleteAllLevelQuest.Invoke();
            }
        }
    }
}
