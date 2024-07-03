using System;

namespace AppFoxTest
{
    public class GameScreenView : AbstractScreenView
    {
        private SceneEventBus _sceneEventBus;
        public override void Inject(DIContainer container)
        {
            base.Inject(container);
            _sceneEventBus = container.GetSingle<SceneEventBus>();
            AddListener();
        }

        public override void Open()
        {
            base.Open();
            _uiService.OpenScreen<QuestHUDScreenView>(true);
        }

        private void OnDestroy()
        {
            RemoveListener();
        }

        private void AddListener()
        {
            _sceneEventBus.OnPlayerSpawn += OnPlayerSpawn;
            _sceneEventBus.OnCompleteAllLevelQuest += OnCompleteAllLevelQuest;
            _sceneEventBus.OnPlayerDeath += OnPlayerDeath;
        }
    
        private void RemoveListener()
        {
            _sceneEventBus.OnPlayerSpawn -= OnPlayerSpawn;
            _sceneEventBus.OnCompleteAllLevelQuest -= OnCompleteAllLevelQuest;
            _sceneEventBus.OnPlayerDeath -= OnPlayerDeath;
        }

        private void OnPlayerSpawn(IControlEntityView view)
        {
            _uiService.OpenScreen<PlayerHUDScreenView>(true);
        }

        private void OnPlayerDeath(IControlEntityView view)
        {
            _uiService.OpenScreen<LoseScreenView>(true);
        }

        private void OnCompleteAllLevelQuest()
        {
            _uiService.OpenScreen<WinScreenView>();
        }
    }
}
