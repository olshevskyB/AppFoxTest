using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace AppFoxTest
{
    public class PlayerHUDScreenView : AbstractScreenView, IEntityView
    {
        private IEntityPresenter _entityPresenter;

        [SerializeField]
        private Image _hpFillBar;

        private EntitySO _entitySO;

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
            var playerModel = _modelLocator.Models.OfType<IEntityModel>().FirstOrDefault(e => e.IsPlayer);
            playerModel.OnAddNewView(this);
        }

        public void GetAttack(float attack)
        {
            
        }

        public void SetAttack(float attack)
        {
            
        }

        public void SetConfig(EntitySO so)
        {
            _entitySO = so;
        }

        public void SetHP(float hp)
        {
            _hpFillBar.fillAmount = hp / _entitySO.HP;
        }

        public void SetMovementSpeed(float speed)
        {
            
        }
    }
}
