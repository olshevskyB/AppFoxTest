using UnityEngine;

namespace AppFoxTest
{
    [CreateAssetMenu(menuName = "GameSO/EntitySO", fileName = nameof(EntitySO))]
    public class EntitySO : ScriptableObject
    {
        [SerializeField]
        private float _hp;
        public float HP => _hp;

        [SerializeField]
        private float _baseAttack;
        public float BaseAttack => _baseAttack;

        [SerializeField]
        private float _movementSpeed;
        public float MovementSpeed => _movementSpeed;

        [SerializeField]
        private MonoEntityView _entityView;
        public MonoEntityView EntityPrefab => _entityView;
    }
}
