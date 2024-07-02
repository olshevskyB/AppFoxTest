using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppFoxTest
{
    public class GameScreenView : AbstractScreenView
    {
        public override void Inject(DIContainer container)
        {
            base.Inject(container);
            AddListener();
        }

        private void OnDestroy()
        {
            RemoveListener();
        }

        private void AddListener()
        {
            
        }

        private void RemoveListener()
        {
            
        }
 
        public override void SetPresenter(IPresenter presenter)
        {

        }
    }
}
