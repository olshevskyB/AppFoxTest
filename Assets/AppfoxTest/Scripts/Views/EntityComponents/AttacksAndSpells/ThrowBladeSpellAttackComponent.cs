using UnityEngine;

namespace AppFoxTest
{
    public class ThrowBladeSpellAttackComponent : SpellComponent
    {
        [SerializeField] Transform _root;
        private ThrowBladeSpell BladeSpell => _spell as ThrowBladeSpell;

        private Vector3 _forward;
        private Vector3 _startPosition;
        private Vector3 _rootInitLocalPosition;

        private void Start()
        {
            _root.gameObject.SetActive(false);
            _rootInitLocalPosition = _root.localPosition;
        }

        protected override void OnStartAttack()
        {
            base.OnStartAttack();
            _root.gameObject.SetActive(true);
            _forward = _root.transform.forward;
            _startPosition = _root.transform.position;
        }

        protected override void UpdateAttack(float time, float progress)
        {
            _root.position = Vector3.Lerp(_startPosition, _startPosition + _forward * BladeSpell.ThrowingRange, progress);
            _root.Rotate(_root.up, BladeSpell.RotationSpeed * Time.deltaTime);
        }

        protected override void OnEndAttack()
        {
            base.OnEndAttack();
            _root.gameObject.SetActive(false);
            _root.localPosition = _rootInitLocalPosition;
            _root.localRotation = Quaternion.identity;
        }
    }
}
