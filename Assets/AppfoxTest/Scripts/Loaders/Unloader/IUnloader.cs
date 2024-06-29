using System;

namespace AppFoxTest
{
    public interface IUnloader: ICloneable
    {
        public void AddObject(UnityEngine.Object obj);
        void Dispose();
        public void Unload();
    }
}