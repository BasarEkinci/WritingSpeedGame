using System.Collections.Generic;
using Controller;
using Signals;
using UnityEngine;

namespace Managers
{
    public class BotCarManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> tires;

        private float _maxSpeed;
        private float _currentSpeed;
        private float _duration;
        private bool _isRaceStarted;

        private void OnEnable()
        {
            RacingSignals.Instance.OnRaceStart += OnRaceStart;
            CoreGameSignals.Instance.OnGameStart += OnGameStart;
        }

        private void Start()
        {
            _maxSpeed = 15f;
        }

        private void Update()
        {
            if (_isRaceStarted)
            {
                AnimateTires();
            }
            else
            {
                StopCar();
            }
            transform.position += Vector3.forward * (_currentSpeed * Time.deltaTime);
            Debug.Log(_currentSpeed);
        }

        private void OnDisable()
        {
            RacingSignals.Instance.OnRaceStart -= OnRaceStart;
            CoreGameSignals.Instance.OnGameStart -= OnGameStart;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Finish"))
            {
                _isRaceStarted = false;
            }
        }

        private void OnGameStart()
        {
            switch (SettingsController.Instance.Difficulty)
            {
                case Difficulty.Easy:
                    _duration = 45f;
                    break;
                case Difficulty.Medium:
                    _duration = 30;
                    break;
                case Difficulty.Hard:
                    _duration = 45;
                    break;
                case Difficulty.AgainstYourself:
                    break;
            }
        }

        private void OnRaceStart()
        {
            _isRaceStarted = true;
            _maxSpeed = 5f;
        }
        
        private void StopCar()
        {
            float speed = Mathf.Lerp(_currentSpeed, 0, Time.deltaTime);
            _currentSpeed = speed;
        }
        
        private void AnimateTires()
        {
            foreach (var tire in tires)
            {
                tire.transform.Rotate(Vector3.right, 1000 * Time.deltaTime);
            }
        }
    }
}
