using System.Collections.Generic;

namespace AppFoxTest
{
    public class PlayerEntityModel : EntityModel, IPlayerEntityModel, IInjectable
    {
        private List<ICollectable> _collectables = new List<ICollectable>();

        private SceneEventBus _sceneEventBus;

        public PlayerEntityModel(EntitySO so, int id) : base(so, id)
        {
        }

        public void Collect(ICollectable collectable)
        {
            _collectables.Add(collectable);
            collectable.Collect();
            _sceneEventBus.OnPlayerCollect?.Invoke(collectable);
        }

        public void Inject(DIContainer container)
        {
            _sceneEventBus = container.GetSingle<SceneEventBus>();
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
