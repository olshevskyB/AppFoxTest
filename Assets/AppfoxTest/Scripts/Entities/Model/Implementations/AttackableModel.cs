namespace AppFoxTest
{
    public class AttackableModel : IAttackableModel 
    {
        public float _baseAttack;

        public float CalculateAttack()
        {
            return _baseAttack;
        }
    }
}
