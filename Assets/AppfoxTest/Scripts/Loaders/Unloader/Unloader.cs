using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace AppFoxTest
{
    public class Unloader : IUnloader, IInjectable
    {
        List<UnityEngine.Object> objectForUnload = new List<UnityEngine.Object>();

        private GlobalEventBus _globalEventBus;

        public void Inject(DIContainer container)
        {
            _globalEventBus = container.GetSingle<GlobalEventBus>();
            AddListeners();
        }

        private void AddListeners()
        {
            _globalEventBus.OnUnloadEntity += OnUnloadEntity;
        }

        private void RemoveListeners()
        {
            _globalEventBus.OnUnloadEntity -= OnUnloadEntity;

        }

        private void OnUnloadEntity(IEntityView view)
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
                _globalEventBus = this._globalEventBus,
            };
            unloader.AddListeners();
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