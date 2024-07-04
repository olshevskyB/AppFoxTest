using UnityEngine;

namespace AppFoxTest
{
    public class CameraController : MonoBehaviour, IInjectable
    {
        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private Vector3 _cameraOffset = new Vector3(0, 20f, 0);

        [SerializeField]
        private Transform _target;

        [SerializeField]
        private float _cameraSpeed = 5f;

        private SceneEventBus _sceneEventBus;

        public void Inject(DIContainer container)
        {
            _sceneEventBus = container.GetSingle<SceneEventBus>();
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            ResetPosition();
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

        private void ResetPosition()
        {
            if (_target != null)
            {
                transform.position = _target.position + _cameraOffset;
            }
        }

        private void UpdatePosition()
        {
            if (_target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target.position + _cameraOffset, _cameraSpeed * Time.deltaTime);
            }
        }
    }
}
