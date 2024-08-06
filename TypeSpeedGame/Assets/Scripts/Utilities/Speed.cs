using UnityEngine;

namespace Utilities
{
    public class Speed : MonoBehaviour
    {
        public float CurrentSpeed => _currentSpeed;
        
        private float _currentSpeed;
        
        internal void IncreaseSpeed(float amount)
        {
            _currentSpeed += amount;
        }
        
        internal void DecreaseSpeed(float amount)
        {
            _currentSpeed -= amount;
        }
    }
}