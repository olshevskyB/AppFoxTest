using UnityEngine;

namespace AppFoxTest
{
    public class SweepAttackComponent : AttackComponent
    {
        [SerializeField]
        private Vector2 _startAndFinaleRotationY = new Vector2(-45f, 45f);

        [SerializeField]
        private Transform _hurtBoxesRoot;

        [SerializeField]
        private float _animationStartTime, _animationEndTime;

        protected void Start()
        {
            _hurtBoxesRoot.gameObject.SetActive(false);
        }

        protected override void OnStartAttack()
        {
            base.OnStartAttack();
            _hurtBoxesRoot.gameObject.SetActive(true);
        }

        protected override void UpdateAttack(float time, float progress)
        {
            if (time < _animationStartTime || time > _animationEndTime)
            {
                _hurtBoxesRoot.gameObject.SetActive(false);
                return;
            }
            else
            {
                _hurtBoxesRoot.gameObject.SetActive(true);
            }
            float angle = Mathf.Lerp(_startAndFinaleRotationY.x, _startAndFinaleRotationY.y, progress);
            _hurtBoxesRoot.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
        }

        protected override void OnEndAttack()
        {
            base.OnEndAttack();
            _hurtBoxesRoot.gameObject.SetActive(false);
        }
    }
}
