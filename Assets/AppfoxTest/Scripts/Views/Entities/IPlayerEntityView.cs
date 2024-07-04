using System.Collections.Generic;

namespace AppFoxTest
{
    public interface IPlayerEntityView : IEntityView
    {
        public void Collect(ICollectable collectable);

        public void SetMana(float mana);

        public void SetSpells(List<AbstractSpell> spells);
    }
}
