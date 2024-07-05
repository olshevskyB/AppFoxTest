using UnityEngine;

namespace AppFoxTest
{
    [CreateAssetMenu(menuName = "Spells/InvokeSkullSpell", fileName = nameof(InvokeSkullSpell))]
    public class InvokeSkullSpell : AbstractSpell
    {
        [SerializeField]
        private float _range;
        public float Range => _range;
    }
}
