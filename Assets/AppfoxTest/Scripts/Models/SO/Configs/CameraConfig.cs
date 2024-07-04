using UnityEngine;

namespace AppFoxTest
{
    [CreateAssetMenu(fileName = "CameraConfig", menuName = "Configs/CameraConfig")]
    public class CameraConfig : ScriptableObject
    {
        [SerializeField]
        private CameraController _cameraController;

        public CameraController CameraPrefab => _cameraController;
    }
}
