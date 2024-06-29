namespace AppFoxTest
{
    public interface IEntityModel: IModel
    {
        public float HP
        {
            get;
            set;
        }
        public float CalculateAttack();       
        public float CalculateMovementSpeed();
    }
}