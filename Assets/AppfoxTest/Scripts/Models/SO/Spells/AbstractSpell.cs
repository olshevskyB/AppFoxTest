using UnityEngine;

namespace AppFoxTest
{
    public abstract class AbstractSpell : ScriptableObject
    {
        [SerializeField]
        private float _manaConsume;

        public float ManaConsume => _manaConsume;

        [SerializeField]
        private float _damage;
        public float Damage => _damage;

        [SerializeField]
        private SpellComponent _spellPrefab;
        public SpellComponent SpellPrefab => _spellPrefab;

        [SerializeField]
        private Sprite _icon;
        public Sprite Icon => _icon;
    }
}
