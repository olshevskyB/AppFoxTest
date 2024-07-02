using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppFoxTest
{
    public class DIContainer
    {
        private readonly List<object> _installedObjects = new List<object>();

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
            _installedObjects.Add(o);
        }

        public T GetSingle<T>()
        {
            T installed = _installedObjects.OfType<T>().FirstOrDefault(o => o is T);
            if (installed == null)
            {
                Debug.LogError($"Unable to resolve {typeof(T)}!");
            }
            return installed;
        }

        public T GetTransient<T>() where T: ICloneable
        {
            T installed = _installedObjects.OfType<T>().FirstOrDefault(o => o is T);
            if (installed == null)
            {
                Debug.LogError($"Unable to resolve {typeof(T)}!");
            }
            return (T)installed.Clone();
        }

        public IEnumerable<T> GetCollection<T>()
        {
            IEnumerable<T> installed = _installedObjects.OfType<T>();
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
