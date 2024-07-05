using UnityEngine;
using UnityEngine.UI;

namespace AppFoxTest
{
    public class Icon : MonoBehaviour
    {
        [SerializeField]
        private Image _image;

        private Color _startColor;

        [SerializeField]
        private Color _inactiveColor;

        private void Start()
        {
            _startColor = _image.color;
        }

        public Sprite Sprite
        {
            set
            {
                _image.sprite = value;
                if (value == null)
                {
                    gameObject.SetActive(false);
                }
            }
        }

        public void SetInactive(bool inactive)
        {
            _image.color = inactive ? _inactiveColor : _startColor;
        }
    }
}
