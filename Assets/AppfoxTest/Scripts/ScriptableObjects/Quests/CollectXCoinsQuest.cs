using UnityEngine;

namespace AppFoxTest
{
    [CreateAssetMenu(menuName = "Quests/CollectXCoinsQuest", fileName = nameof(CollectXCoinsQuest))]
    public class CollectXCoinsQuest : AbstractQuest
    {
        [SerializeField]
        private int _collectCoinsRequire;
        public int CollectCoinsRequire => _collectCoinsRequire;

        public override string QuestDescription => $"Collect {_progress.Progress}/{_collectCoinsRequire} coins";

        private QuestTrackProgress _progress;

        public override void SetEvents(GlobalEventBus globalEvents, SceneEventBus sceneEvents)
        {
            _progress = new QuestTrackProgress();
            _sceneEvents = sceneEvents;
            AddListeners();
        }

        private void AddListeners()
        {
            _sceneEvents.OnPlayerCollect += OnPlayerCollect;
            _sceneEvents.OnLevelLoaded += OnLevelLoaded;
        }

        private void RemoveListeners()
        {
            _sceneEvents.OnPlayerCollect += OnPlayerCollect;
            _sceneEvents.OnLevelLoaded -= OnLevelLoaded;
        }

        private void OnLevelLoaded(LevelView view)
        {
            _progress = new QuestTrackProgress();
        }


        private void OnPlayerCollect(ICollectable collectable)
        {
            if (collectable is Coin)
            {
                _progress.Progress++;
                if (_progress.Progress >= _collectCoinsRequire)
                {
                    OnCompleteQuest();
                    return;
                }
                OnQuestProgress();
            }
        }

        private struct QuestTrackProgress
        {
            public int Progress;
        }
    }
}
