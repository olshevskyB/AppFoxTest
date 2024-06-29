using UnityEngine;

namespace AppFoxTest
{
    public class HurtBoxComponent : MonoBehaviour
    {
        [SerializeField]
        private AttackComponent _attackComponent;

        public AttackComponent AttackComponent => _attackComponent;
    }
}
