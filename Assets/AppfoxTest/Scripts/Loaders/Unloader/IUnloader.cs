using System;

namespace AppFoxTest
{
    public interface IUnloader: ICloneable
    {
        public void AddObject(UnityEngine.Object obj);

        public void Unload();
    }
}