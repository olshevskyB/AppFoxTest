using System.Collections.Generic;

namespace AppFoxTest
{
    public class PlayerEntityModel : EntityModel, IPlayerEntityModel, IInjectable, IUpdateModel
    {
        private List<ICollectable> _collectables = new List<ICollectable>();
        private List<IPlayerPresenter> _playerPresenter = new List<IPlayerPresenter>();

        private SceneEventBus _sceneEventBus;

        private float _mana;

        public float Mana
        {
            get
            {
                return _mana;
            }
            set
            {
                _mana = value;
                _playerPresenter.ForEach(pp => pp.UpdateMana());
            }
        }
        private List<AbstractSpell> _spells;
        public List<AbstractSpell> Spells => _spells;

        private float _manaRegeneration;
        public float ManaRegeneration => _manaRegeneration;

        public PlayerEntityModel(EntitySO so, int id) : base(so, id)
        {
            if (so is PlayerSO playerSO)
            {
                _mana = playerSO.Mana;
                _manaRegeneration = playerSO.ManaRegen;
                _spells = playerSO.Spells;
            }
        }

        public void Inject(DIContainer container)
        {
            _sceneEventBus = container.GetSingle<SceneEventBus>();
        }

        public override void AddPresenter(IPresenter presenter)
        {
            base.AddPresenter(presenter);
            if (presenter is IPlayerPresenter playerPresenter)
            {
                _playerPresenter.Add(playerPresenter);
            }
        }

        public void Collect(ICollectable collectable)
        {
            _collectables.Add(collectable);
            collectable.Collect();
            _sceneEventBus.OnPlayerCollect?.Invoke(collectable);
        }

        public override void AddView(IView view)
        {
            base.AddView(view);
            if ((view is PlayerHUDScreenView hud))
            {
                new PlayerPresenter(hud, this);
                return;
            }
            if (view is PlayerMonoEntityView player)
            {
                new PlayerPresenter(player, this);
                return;
            }
        }

        public void SetSpells(List<AbstractSpell> spells)
        {
            _spells = spells;
            _playerPresenter.ForEach(pp => pp.UpdateSpells());
        }

        public void Update(float deltaTime)
        {
            Mana += _manaRegeneration * deltaTime;
        }
    }
}
