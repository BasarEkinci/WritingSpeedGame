using System;
using System.Collections.Generic;
using Controller;
using Signals;
using UnityEngine;

namespace Managers
{
    public class BotCarManager : MonoBehaviour
    {
        [SerializeField] private Transform endPoint;
        [SerializeField] private Transform startPoint;
        [SerializeField] private List<GameObject> tires;

        private float _maxSpeed;
        private float _currentSpeed;
        private float _duration;
        private float _elapsedTime;
        private bool _isRaceStarted;
        private float _acceleration;

        private void OnEnable()
        {
            RacingSignals.Instance.OnRaceStart += OnRaceStart;
            RacingSignals.Instance.OnRaceEnd += OnRaceEnd;
            CoreGameSignals.Instance.OnGameStart += OnGameStart;
        }

        private void Start()
        {
            _maxSpeed = 14f;
        }

        private void Update()
        {
            if (_isRaceStarted)
            {
                SetAcceleration();
                transform.position += Vector3.forward * (_currentSpeed * Time.deltaTime);
                AnimateTires();
            }
        }

        private void OnDisable()
        {
            RacingSignals.Instance.OnRaceStart -= OnRaceStart;
            RacingSignals.Instance.OnRaceEnd -= OnRaceEnd;
            CoreGameSignals.Instance.OnGameStart -= OnGameStart;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Finish"))
            {
                _currentSpeed = Mathf.Lerp(_currentSpeed,0,Time.deltaTime);
            }
        }

        private void OnGameStart()
        {
            switch (SettingsController.Instance.Difficulty)
            {
                case Difficulty.Easy:
                    _duration = 70f;
                    break;
                case Difficulty.Medium:
                    _duration = 55f;
                    break;
                case Difficulty.Hard:
                    _duration = 45f;
                    break;
                case Difficulty.AgainstYourself:
                    break;
            }
        }

        private void OnRaceEnd()
        {
            _isRaceStarted = false;   
        }

        private void OnRaceStart()
        {
            _isRaceStarted = true;
        }
        
        private void AnimateTires()
        {
            foreach (var tire in tires)
            {
                tire.transform.Rotate(Vector3.right, 1000 * Time.deltaTime);
            }
        }
        private void SetAcceleration()
        {
            if (_elapsedTime < _duration)
            {
                _elapsedTime += Time.deltaTime;
                float t = _elapsedTime / _duration;
                _currentSpeed = Mathf.Lerp(0, _maxSpeed, t);
            }
        }
    }
}
