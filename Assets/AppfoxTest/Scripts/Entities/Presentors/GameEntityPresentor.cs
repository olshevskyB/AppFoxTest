namespace AppFoxTest
{
    public class GameEntityPresentor : IEntityPresentor
    {
        private IMovableModel _movableModel;
        private IKillableModel _killableModel;
        private IAttackableModel _attackableModel;

        private IEntityView _entityView;

        public void UpdateMovementSpeed()
        {
            _entityView.SetMovementSpeed(_movableModel.CalculateMovementSpeed());
        }

        public void UpdateAttackValue()
        {
            _entityView.SetAttack(_attackableModel.CalculateAttack());
        }

        public void UpdateHP()
        {
            _entityView.SetHP(_killableModel.HP);
        }

        public void GetAttack(float value)
        {
            _killableModel.HP -= value;
        }
    }
}