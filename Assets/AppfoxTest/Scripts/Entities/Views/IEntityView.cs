namespace AppFoxTest
{
    public interface IEntityView
    {
        public int ID
        {
            get;
        }

        public void SetHP(float hp);

        public void SetMovementSpeed(float speed);

        public void SetAttack(float attack);

        public void GetAttack(float attack);
    }
}
