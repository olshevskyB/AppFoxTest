namespace AppFoxTest
{
    public interface IEntityPresenter : IPresenter
    {
        public void GetAttack(float value);
        public void UpdateAttackValue();
        public void UpdateHP();
        public void UpdateMovementSpeed();
    }
}
