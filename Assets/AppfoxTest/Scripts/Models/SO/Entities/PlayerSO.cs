using System.Collections.Generic;
using UnityEngine;

namespace AppFoxTest
{
    [CreateAssetMenu(menuName = "GameSO/PlayerSO", fileName = nameof(PlayerSO))]
    public class PlayerSO : EntitySO
    {
        [SerializeField]
        private float _mana = 50f;

        public float Mana => _mana;

        [SerializeField]
        private float _manaRegen = 1f;
        public float ManaRegen => _manaRegen;

        [SerializeField]
        private List<AbstractSpell> _spells;
        public List<AbstractSpell> Spells => _spells;
    }
}
