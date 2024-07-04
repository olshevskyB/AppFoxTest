using System.Collections.Generic;

namespace AppFoxTest
{
    public interface IPlayerEntityModel : IEntityModel
    {
        public float Mana
        {
            get;
            set;
        }

        public float ManaRegeneration
        {
            get;
        }

        public List<AbstractSpell> Spells { get; }

        public void SetSpells(List<AbstractSpell> spells);

        public void Collect(ICollectable collectable);
    }
}
