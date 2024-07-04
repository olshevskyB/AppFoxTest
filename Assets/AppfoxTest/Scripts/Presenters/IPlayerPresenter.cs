using System.Collections.Generic;

namespace AppFoxTest
{
    public interface IPlayerPresenter : IPresenter
    {
        public void Collect(ICollectable collectable);

        public bool TryUseSpell(AbstractSpell abstractSpell);

        public void UpdateMana();

        public void UpdateSpells();
    }
}
