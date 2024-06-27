using UnityEngine;

namespace AppFoxTest
{
    public class PrefabService : MonoBehaviour, IPrefabService, IInjectable
    {
        private IPrefabLoader _prefabLoader;

        public void Inject(DIContainer container)
        {
            _prefabLoader = container.GetSingle<IPrefabLoader>();
        }
    }
}