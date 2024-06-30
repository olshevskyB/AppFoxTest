using UnityEngine;

namespace AppFoxTest
{
    public class CameraController : MonoBehaviour, IInjectable
    {
        [SerializeField]
        private Camera _camera;

        private Transform _target;

        private SceneEventBus _sceneEventBus;

        public void Inject(DIContainer container)
        {
            _sceneEventBus = container.GetSingle<SceneEventBus>();
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public void Update()
        {
            if (_target == null)
                return;
            Vector3 mousePosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Vector3.Distance(transform.position, _target.transform.position)));
            _sceneEventBus.OnMouseUpdate?.Invoke(mousePosition);
        }

        public void LateUpdate()
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            if (_target != null)
            {
                transform.position = _target.position + Vector3.up * 15f;
            }            
        }
    }
}
