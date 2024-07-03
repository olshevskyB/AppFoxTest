namespace AppFoxTest
{
    public interface IPlayerPresenter : IPresenter
    {
        public void Collect(ICollectable collectable);
    }
}
