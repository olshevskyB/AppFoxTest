using System.Collections.Generic;
using UnityEngine;

namespace AppFoxTest
{
    public class Unloader : IUnloader
    {
        List<UnityEngine.Object> objectForUnload = new List<UnityEngine.Object>();

        public void AddObject(UnityEngine.Object obj)
        {
            objectForUnload.Add(obj);
        }

        public void Unload()
        {
            foreach (UnityEngine.Object mono in objectForUnload)
            {
                GameObject.Destroy(mono);
            }
        }
    }
}