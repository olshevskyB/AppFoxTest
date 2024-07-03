namespace AppFoxTest
{
    public class PlayerPresenter : GameEntityPresenter, IPlayerPresenter
    {
        private IPlayerEntityModel PlayerModel => _model as IPlayerEntityModel;

        public PlayerPresenter(IEntityView view, IEntityModel model) : base(view, model)
        {
        }

        public void Collect(ICollectable collectable)
        {
            PlayerModel.Collect(collectable);
        }
    }
}
