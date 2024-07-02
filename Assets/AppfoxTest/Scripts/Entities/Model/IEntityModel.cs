namespace AppFoxTest
{
    public interface IEntityModel : IModel
    {
        public float HP
        {
            get;
            set;
        }

        public EntitySO Config
        {
            get;
        }

        public bool IsPlayer
        {
            get;
        }

        public float CalculateAttack();
        public float CalculateMovementSpeed();
    }
}