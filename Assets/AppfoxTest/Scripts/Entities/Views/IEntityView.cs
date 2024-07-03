namespace AppFoxTest
{
    public interface IEntityView : IView, IInitializable
    {
        public int ID
        {
            get;
            set;
        }

        public void SetHP(float hp);

        public void SetMovementSpeed(float speed);

        public void SetAttack(float attack);

        public void SetConfig(EntitySO so);

        public void GetAttack(float attack);
    }
}
