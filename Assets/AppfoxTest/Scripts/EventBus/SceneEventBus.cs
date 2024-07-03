using System;
using UnityEngine;

namespace AppFoxTest
{
    public class SceneEventBus
    {
        public Action<LevelView> OnLevelLoaded;
        public Action OnInvokeNextLevel;
        public Action<int> OnInvokeLevel;

        public Action<GameObjectSO<LevelView>, float> OnLevelLoadingProgress;
        public Action<Vector2> OnAxisPressed;
        public Action OnJumpButtonPressed;
        public Action OnAttackButtonPressed;
        public Action<Vector3> OnMouseUpdate;

        public Action<IControlEntityView> OnEntitySpawn;
        public Action<IControlEntityView> OnEntityDead;
        public Action<IControlEntityView> OnPlayerSpawn;
        public Action<IControlEntityView> OnPlayerDeath;
        public Action<ICollectable> OnPlayerCollect;

        public Action<AbstractQuest> OnQuestComplete;
        public Action<AbstractQuest> OnQuestProgress;
        public Action OnCompleteAllLevelQuest;
        public Action OnInvokeRestart;
        
    }
}
