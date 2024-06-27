using System;
using UnityEngine;

namespace AppFoxTest
{
    public class SceneEventBus
    {
        public Action<LevelView> OnLevelLoaded;
        public Action<LevelSO> OnInvokeNextLevel;

        public Action<GameObjectSO<LevelView>, float> OnLevelLoadingProgress;
        public Action<Vector2> OnAxisPressed;
        public Action OnJumpButtonPressed;
        public Action OnAttackButtonPressed;
    }
}
