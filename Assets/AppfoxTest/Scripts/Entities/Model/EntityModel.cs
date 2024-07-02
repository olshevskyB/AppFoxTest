using System.Collections.Generic;
using UnityEngine;

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
                Debug.Log($"Attacked model {_id} Current HP {_hp} New Value {value}");
                if (value == HP)
                    return;               
                _hp = value;
                _entityPresentors.ForEach(p => p.UpdateHP());
            }
        }

        private int _id;

        public EntityModel(EntitySO so, int id)
        {
            _entitySO = so;
            _baseAttack = _entitySO.BaseAttack;
            _baseSpeed = _entitySO.MovementSpeed;
            _hp = _entitySO.HP;
            _id = id;
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

        public void TrySubscribeView(IView view)
        {
            if (view is IEntityView entityView && entityView.ID == _id)
            {
                new GameEntityPresenter(entityView, this);
            }
        }

        public string GetLogText()
        {
            return $"Entity ID: \n {_id} HP: {_hp} \n BaseAttack: {_baseAttack} \n BaseSpeed: {_baseSpeed} \n____________";
        }
    }
}