namespace AppFoxTest
{
    public interface IEntityModel : ILevelContextModel
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

        public float CalculateAttack();
        public float CalculateMovementSpeed();
    }
}