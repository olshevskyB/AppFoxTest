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

        private PlayerSO _playerSo;

        private ModelLocator _modelLocator;

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
        }

        public void SetMovementSpeed(float speed)
        {
            
        }

        public void Collect(ICollectable collectable)
        {
            
        }

        public void SetSpells(List<AbstractSpell> spells)
        {
            
        }
    }
}
