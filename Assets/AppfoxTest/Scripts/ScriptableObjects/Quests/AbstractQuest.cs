using UnityEngine;

namespace AppFoxTest
{
    public abstract class AbstractQuest : ScriptableObject
    {
        protected SceneEventBus _sceneEvents;

        public abstract string QuestDescription { get; }
        public abstract void SetEvents(GlobalEventBus globalEvents, SceneEventBus sceneEvents);

        protected void OnQuestProgress()
        {
            _sceneEvents.OnQuestProgress?.Invoke(this);
        }

        protected void OnCompleteQuest()
        {
            _sceneEvents.OnQuestComplete?.Invoke(this);
        }
    }
}
