namespace AppFoxTest
{
    public class GameEntityPresenter : AbstractPresenter<IEntityView, IEntityModel>, IEntityPresenter
    {
        public GameEntityPresenter(IEntityView view, IEntityModel model) : base(view, model)
        {

        }

        public override void UpdateAllValues()
        {
            UpdateConfig();
            UpdateMovementSpeed();
            UpdateAttackValue();
            UpdateHP();
        }

        public void UpdateMovementSpeed()
        {
            _view.SetMovementSpeed(_model.CalculateMovementSpeed());
        }

        public void UpdateAttackValue()
        {
            _view.SetAttack(_model.CalculateAttack());
        }

        public void UpdateConfig()
        {
            _view.SetConfig(_model.Config);
        }

        public void UpdateHP()
        {
            _view.SetHP(_model.HP);
        }

        public void GetAttack(float value)
        {
            _model.HP -= value;
        }      
    }
}