namespace AppFoxTest
{
    public class KillableModel : BaseEntityModel, IKillableModel
    {
        private float _hp;
        public float HP
        {
            get
            {
                return _hp;
            }
            set
            {
                if (value == HP)
                    return;
                _entityPresentors.ForEach(p => p.UpdateHP());
                _hp = value;
            }
        }
    }
}
