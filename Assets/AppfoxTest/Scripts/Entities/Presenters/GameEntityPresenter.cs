namespace AppFoxTest
{
    public class GameEntityPresenter : IEntityPresenter
    {
        private IEntityModel _entityModel;

        private IEntityView _entityView;

        public GameEntityPresenter(IEntityModel entityModel, IEntityView entityView)
        {
            _entityView = entityView;
            _entityView.SetPresenter(this);

            _entityModel = entityModel;
            _entityModel.AddPresenter(this);            
        }

        public void UpdateAllValues()
        {
            UpdateMovementSpeed();
            UpdateAttackValue();
            UpdateHP();
        }

        public void UpdateMovementSpeed()
        {
            _entityView.SetMovementSpeed(_entityModel.CalculateMovementSpeed());
        }

        public void UpdateAttackValue()
        {
            _entityView.SetAttack(_entityModel.CalculateAttack());
        }

        public void UpdateHP()
        {
            _entityView.SetHP(_entityModel.HP);
        }

        public void GetAttack(float value)
        {
            _entityModel.HP -= value;
        }      
    }
}