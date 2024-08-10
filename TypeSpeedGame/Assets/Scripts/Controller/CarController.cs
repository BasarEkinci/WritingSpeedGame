using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class CarController : MonoBehaviour
    {
        private const float MaxSpeed = 17f;
        private float _speed;
        internal void AddSpeed(float value)
        {
            if (_speed < MaxSpeed)
            {
                _speed += value;
            }
        }
        internal void ReduceSpeed(float value)
        {
            _speed -= value;
        }
        internal void MoveCar(Vector3 direction)
        {
            transform.position += direction * (_speed * Time.deltaTime);
            Debug.Log(_speed);
        }
        internal void AnimatesTires(List<GameObject> tires)
        {
            foreach (var tire in tires)
            {
                tire.transform.Rotate(Vector3.right, _speed / 2f);
            }
        }
        internal void StopCar()
        {
            _speed = Mathf.Lerp(_speed,0,Time.deltaTime);
        }
    }
}
