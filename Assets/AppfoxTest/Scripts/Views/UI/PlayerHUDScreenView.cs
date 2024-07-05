using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace AppFoxTest
{
    public class PlayerHUDScreenView : AbstractScreenView, IPlayerEntityView
    {
        [SerializeField]
        private Image _hpFillBar;

        [SerializeField]
        private Image _manaFillBar;

        [SerializeField]
        private List<Icon> _icons;

        private Dictionary<AbstractSpell, Icon> _spells = new Dictionary<AbstractSpell, Icon>();

        private PlayerSO _playerSo;

        private ModelLocator _modelLocator;

        private float _mana;

        public int ID 
        { 
            get; 
            set; 
        }

        public override void Inject(DIContainer container)
        {
            base.Inject(container);
            _modelLocator = container.GetSingle<ModelLocator>();         
        }

        public override void Open()
        {
            base.Open();
            var playerModel = _modelLocator.Models.OfType<IPlayerEntityModel>().FirstOrDefault();
            playerModel.AddView(this);
        }

        public void GetAttack(float attack)
        {
            
        }

        public void SetAttack(float attack)
        {
            
        }

        public void SetConfig(EntitySO so)
        {
            _playerSo = so as PlayerSO;
        }

        public void SetHP(float hp)
        {
            _hpFillBar.fillAmount = hp / _playerSo.HP;
        }

        public void SetMana(float mana)
        {
            _manaFillBar.fillAmount = mana / _playerSo.Mana;
            CheckMana();
        }

        public void SetMovementSpeed(float speed)
        {
            
        }

        public void Collect(ICollectable collectable)
        {
            
        }

        public void SetSpells(List<AbstractSpell> spells)
        {
            _spells.Clear();

            for (int i = 0; i < _icons.Count; i++)
            {
                Sprite sprite = spells.Count >= i ? null : spells[i].Icon;
                _icons[i].Sprite = sprite;
                if (spells.Count >= i)
                    return;
                _spells[spells[i]] = _icons[i];
            }
            CheckMana();
        }

        private void CheckMana()
        {
            foreach (var spell in _spells)
            {
                spell.Value.SetInactive(spell.Key.ManaConsume > _mana);
            }
        }
    }
}
