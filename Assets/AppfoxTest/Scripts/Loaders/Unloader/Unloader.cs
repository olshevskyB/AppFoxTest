using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace AppFoxTest
{
    public class Unloader : IUnloader, IInjectable
    {
        List<UnityEngine.Object> objectForUnload = new List<UnityEngine.Object>();

        private SceneEventBus _sceneEventBus;
        private GlobalEventBus _globalEventBus;

        public void Inject(DIContainer container)
        {
            _globalEventBus = container.GetSingle<GlobalEventBus>();
            WaitSceneEvenBusInitialization();
        }
        
        private void WaitSceneEvenBusInitialization()
        {
            _globalEventBus.OnSceneEventBusInit += OnSceneEvenBusInit;
        }

        private void OnSceneEvenBusInit(SceneEventBus bus)
        {
            _sceneEventBus = bus;
            AddListeners();
            _globalEventBus.OnSceneEventBusInit -= OnSceneEvenBusInit;
        }

        private void AddListeners()
        {
            _sceneEventBus.OnEntityDead += OnEntityDead;
        }     

        private void RemoveListeners()
        {
            _sceneEventBus.OnEntityDead -= OnEntityDead;
            
        }

        private void OnEntityDead(IEntityView view)
        {
            if (view is UnityEngine.Object unityObject)
            {
                Unload(unityObject.GameObject());
            }
        }

        public void AddObject(UnityEngine.Object obj)
        {
            objectForUnload.Add(obj);
        }

        public object Clone()
        {
            var unloader = new Unloader()
            {
                objectForUnload = new List<Object>(),
                _sceneEventBus = this._sceneEventBus,                
            };
            if(_sceneEventBus != null)
                unloader.AddListeners();
            else
            {
                WaitSceneEvenBusInitialization();
            }
            return unloader;
        }
        
        public void Unload()
        {
            foreach (UnityEngine.Object mono in objectForUnload)
            {
                GameObject.Destroy(mono);
            }
        }

        public void Unload(UnityEngine.Object obj)
        {
            if (objectForUnload.Contains(obj))
            {
                GameObject.Destroy(obj);
                objectForUnload.Remove(obj);
            }
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}