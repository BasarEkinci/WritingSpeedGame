using UnityEngine;

namespace Controller
{
    public class SpeedController : MonoBehaviour
    {
        [SerializeField] private float maxSpeed;
        [SerializeField] private float acceleration;
        [SerializeField] private float deceleration;
        
        private float _currentSpeed = 0;
        
        internal void AddSpeed(float speed)
        {
            _currentSpeed += speed;
            if (_currentSpeed > maxSpeed)
            {
                _currentSpeed = maxSpeed;
            }
        }
        
        internal void SubtractSpeed(float speed)
        {
            _currentSpeed -= speed;
            if (_currentSpeed < 0)
            {
                _currentSpeed = 0;
            }
        }
        
        internal void StopCar()
        {
            while (_currentSpeed > 0)
            {
                _currentSpeed -= deceleration;
            }
        }
    }
}