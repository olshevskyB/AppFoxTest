using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        private void OnDestroy()
        {
            RemoveListener();           
        }

        private void AddListener()
        {
            _sceneEventBus.OnPlayerSpawn += OnPlayerSpawn;
        }        

        private void RemoveListener()
        {
            _sceneEventBus.OnPlayerSpawn -= OnPlayerSpawn;
        }

        private void OnPlayerSpawn(IControlEntityView view)
        {
            _uiService.OpenScreen<PlayerHUDScreenView>(true);
        }

        public override void SetPresenter(IPresenter presenter)
        {

        }
    }
}
