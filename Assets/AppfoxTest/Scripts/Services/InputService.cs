using UnityEngine;

namespace AppFoxTest
{
    public class InputService : MonoBehaviour, IInjectable
    {
        private SceneEventBus _sceneEventBus;

        private const string VERTICAL_AXIS = "Vertical";
        private const string HORIZONTAL_AXIS = "Horizontal";

        public void Inject(DIContainer container)
        {
            _sceneEventBus = container.GetSingle<SceneEventBus>();
        }

        public void Update()
        {
            float horizontal = Input.GetAxis(HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(VERTICAL_AXIS);
            Vector2 input = new Vector2(horizontal, vertical);
            if (input.x != 0f || input.y != 0f)
            {
                _sceneEventBus.OnAxisPressed?.Invoke(input);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _sceneEventBus.OnJumpButtonPressed?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _sceneEventBus.OnPauseButtonPressed?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _sceneEventBus.OnSpell1ButtonPressed?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                _sceneEventBus.OnSpell2ButtonPressed?.Invoke();
            }
            if (Input.GetMouseButton(0))
            {
                _sceneEventBus.OnAttackButtonPressed?.Invoke();
            }
        }
    }
}
