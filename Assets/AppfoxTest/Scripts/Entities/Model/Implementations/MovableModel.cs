namespace AppFoxTest
{
    public class MovableModel : IMovableModel
    {
        private float _baseSpeed;

        public float CalculateMovementSpeed()
        {
            return _baseSpeed;
        }
    }
}
