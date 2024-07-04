namespace AppFoxTest
{
    public class PlayerPresenter : GameEntityPresenter, IPlayerPresenter
    {
        private IPlayerEntityModel PlayerModel => _model as IPlayerEntityModel;
        private IPlayerEntityView PlayerEntityView => _view as IPlayerEntityView;

        public PlayerPresenter(IPlayerEntityView view, IEntityModel model) : base(view, model)
        {
        }

        public override void UpdateAllValues()
        {
            base.UpdateAllValues();
            UpdateMana();
            UpdateSpells();
        }

        public void Collect(ICollectable collectable)
        {
            PlayerModel.Collect(collectable);
        }

        public bool TryUseSpell(AbstractSpell abstractSpell)
        {
            if (abstractSpell.ManaConsume > PlayerModel.Mana)
            {
                return false;
            }
            PlayerModel.Mana -= abstractSpell.ManaConsume;
            return true;
        }

        public void UpdateMana()
        {
            PlayerEntityView.SetMana(PlayerModel.Mana);
        }

        public void UpdateSpells()
        {
            PlayerEntityView.SetSpells(PlayerModel.Spells);
        }
    }
}
