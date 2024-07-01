using UnityEngine;

namespace AppFoxTest
{
    [CreateAssetMenu(fileName = "ScreenSO", menuName = "GameSO/ScreenSO")]
    public class ScreenSO : GameObjectSO<AbstractScreenView>
    {
        [SerializeField]
        private AbstractScreenView _screenView;

        public override AbstractScreenView Prefab => _screenView;
    }
}
