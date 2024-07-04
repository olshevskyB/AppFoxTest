using System.Collections.Generic;
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

        private LevelView _currentLevel;
        private List<AbstractQuest> _subscribedQuest = new List<AbstractQuest>();

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
            List<AbstractQuest> unsubQuest = _currentModel.Quests.Where(q => !_subscribedQuest.Any(sq => sq != q)).ToList();
            foreach (AbstractQuest quest in unsubQuest)
            {
                quest.SetEvents(_globalEvent, _sceneEvent);
                _subscribedQuest.Add(quest);
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
