using System.Collections.Generic;

namespace AppFoxTest
{
    public class EntityModel : IEntityModel
    {
        private EntitySO _entitySO;
        private List<IEntityPresenter> _entityPresentors = new List<IEntityPresenter>();

        private float _baseAttack;
        private float _baseSpeed;

        private float _hp;
        public float HP
        {
            get
            {
                return _hp;
            }
            set
            {
                if (value == HP)
                    return;               
                _hp = value;
                _entityPresentors.ForEach(p => p.UpdateHP());
            }
        }

        public EntityModel(EntitySO so)
        {
            _entitySO = so;
            _baseAttack = _entitySO.BaseAttack;
            _baseSpeed = _entitySO.MovementSpeed;
            _hp = _entitySO.HP;
        }

        public float CalculateAttack()
        {
            return _baseAttack;
        }
        public float CalculateMovementSpeed()
        {
            return _baseSpeed;
        }

        public void AddPresenter(IPresenter presenter)
        {
            if (presenter is IEntityPresenter entityPresenter)
            {
                _entityPresentors.Add(entityPresenter);
            }
        }
    }
}