using UnityEngine;

namespace AppFoxTest
{
    public class InvokeSkullAttackComponent : SpellComponent
    {
        [SerializeField] protected Transform _root;
        protected InvokeSkullSpell SkullSpell => _spell as InvokeSkullSpell;

        protected Vector3 _forward;
        protected Vector3 _startPosition;
        protected Vector3 _rootInitLocalPosition;

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
            _root.position = Vector3.Lerp(_startPosition, _startPosition + _forward * SkullSpell.Range, progress);
        }

        protected override void OnEndAttack()
        {
            base.OnEndAttack();
            _root.gameObject.SetActive(false);
            _root.localPosition = _rootInitLocalPosition;
        }
    }
}
