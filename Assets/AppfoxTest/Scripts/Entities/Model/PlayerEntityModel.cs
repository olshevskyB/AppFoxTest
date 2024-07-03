using System.Collections.Generic;

namespace AppFoxTest
{
    public class PlayerEntityModel : EntityModel, IPlayerEntityModel
    {
        private List<ICollectable> _collectables = new List<ICollectable>();

        public PlayerEntityModel(EntitySO so, int id) : base(so, id)
        {
        }

        public void Collect(ICollectable collectable)
        {
            _collectables.Add(collectable);
            collectable.Collect();
        }

        public override void OnAddNewView(IView view)
        {
            base.OnAddNewView(view);
            if ((view is PlayerHUDScreenView hud))
            {
                new GameEntityPresenter(hud, this);
                return;
            }
            if (view is PlayerMonoEntityView player)
            {
                new PlayerPresenter(player, this);
                return;
            }
        }
    }
}
