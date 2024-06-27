namespace AppFoxTest
{
    public interface IUnloader
    {
        public void AddObject(UnityEngine.Object obj);

        public void Unload();
    }
}