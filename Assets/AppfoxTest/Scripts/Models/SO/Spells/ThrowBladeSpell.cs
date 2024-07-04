using UnityEngine;

namespace AppFoxTest
{
    [CreateAssetMenu(menuName = "Spells/ThrowBladeSpell", fileName = nameof(ThrowBladeSpell))]
    public class ThrowBladeSpell : AbstractSpell
    {
        [SerializeField]
        private float _throwingRange = 10f;
        public float ThrowingRange => _throwingRange;

        [SerializeField]
        protected float _rotationSpeed = 720f;
        public float RotationSpeed => _rotationSpeed;
    }
}
