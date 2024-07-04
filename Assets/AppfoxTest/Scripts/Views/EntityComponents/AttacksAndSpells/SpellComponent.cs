namespace AppFoxTest
{
    public abstract class SpellComponent : AttackComponent
    {
        protected AbstractSpell _spell;

        public AbstractSpell Spell => _spell;

        public void SetSpell(AbstractSpell spell)
        {
            _spell = spell;
        }
    }
}
