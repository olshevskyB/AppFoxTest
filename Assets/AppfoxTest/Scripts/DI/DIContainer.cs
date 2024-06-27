using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppFoxTest
{
    public class DIContainer
    {
        private readonly List<object> _installedObjectsInContext = new List<object>();

        private List<object> _installedObjects
        {
            get
            {
                if (_wrappedDIContainer == null)
                    return _installedObjectsInContext;
                return _installedObjectsInContext.Union(_installedObjects).ToList();
            }
        }

        private DIContainer _wrappedDIContainer;

        public event Action<object> OnAddObjectToDI;

        public DIContainer()
        {

        }

        public DIContainer(DIContainer diContainer)
        {
            _wrappedDIContainer = diContainer;
        }

        public void AddNewObjectAndInit(object o)
        {
            if (o is IInjectable injectable)
            {
                Inject(injectable);
            }
            if (o is IInitializable initializable)
            {
                initializable.Init();
            }
            _installedObjectsInContext.Add(o);
            OnAddObjectToDI?.Invoke(o);
        }

        public T GetSingle<T>()
        {
            T installed = _installedObjectsInContext.OfType<T>().FirstOrDefault(o => o is T);
            if (installed == null)
            {
                Debug.LogError($"Unable to resolve {typeof(T)}!");
            }
            return installed;
        }

        public IEnumerable<T> GetCollection<T>()
        {
            IEnumerable<T> installed = _installedObjectsInContext.OfType<T>();
            if (installed.Count() <= 0)
            {
                Debug.LogError($"Unable to resolve {typeof(T)}!");
            }
            return installed;
        }

        public void Inject(IInjectable injectable)
        {
            injectable.Inject(this);
        }
    }
}
