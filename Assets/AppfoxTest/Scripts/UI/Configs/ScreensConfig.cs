using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppFoxTest
{
    [CreateAssetMenu(fileName = "ScreensConfig", menuName = "Configs/ScreensConfig")]
    public class ScreensConfig : ScriptableObject
    {
        [SerializeField]
        private List<ScreenSO> _viewPrefabs;
        public IReadOnlyList<ScreenSO> ViewPrefabs => _viewPrefabs;

        [SerializeField]
        private Canvas _canvasPrefab;
        public Canvas CanvasPrefab => _canvasPrefab;

        [SerializeField]
        private ScreenSO _startScreen;
        public ScreenSO StartScreen => _startScreen;

        public ScreenSO this[Type type]
        {
            get
            {
                var prefab = _viewPrefabs.FirstOrDefault(p => p.Prefab.GetType() == type);
                return prefab;
            }
        }
    }
}
