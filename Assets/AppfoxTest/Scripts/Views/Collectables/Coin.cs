using UnityEngine;

namespace AppFoxTest
{
    public class Coin : MonoBehaviour, ICollectable
    {
        public void Collect()
        {
            Destroy(gameObject);
        }
    }
}
