using System;
using UnityEditor;
using UnityEngine;

namespace AppFoxTest
{
    [CreateAssetMenu(menuName = "Quests/KillXEnemiesQuest", fileName = nameof(KillXEnemiesQuest))]
    public class KillXEnemiesQuest : AbstractQuest
    {
        [SerializeField]
        private int _enemiesCountRequire;
        public int EnemiesCountRequire => _enemiesCountRequire;

        public override string QuestDescription => $"Kill {_progress.Progress}/{_enemiesCountRequire} enemies";

        private QuestTrackProgress _progress;

        public override void SetEvents(GlobalEventBus globalEvents, SceneEventBus sceneEvents)
        {
            _progress = new QuestTrackProgress();
            _sceneEvents = sceneEvents;
            AddListeners();
        }

        private void AddListeners()
        {
            _sceneEvents.OnEntityDead += OnEntityDead;
            _sceneEvents.OnLevelLoaded += OnLevelLoaded;
        }     

        private void RemoveListeners()
        {
            _sceneEvents.OnEntityDead -= OnEntityDead;
            _sceneEvents.OnLevelLoaded -= OnLevelLoaded;
        }
        private void OnLevelLoaded(LevelView view)
        {
            _progress = new QuestTrackProgress();
        }

        private void OnEntityDead(IControlEntityView entity)
        {
            if (entity.Controller is EnemyController)
            {                
                _progress.Progress++;
                if (_progress.Progress >=_enemiesCountRequire)
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
