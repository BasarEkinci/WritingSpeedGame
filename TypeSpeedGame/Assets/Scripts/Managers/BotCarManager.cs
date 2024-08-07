using System;
using Controller;
using Cysharp.Threading.Tasks;
using Signals;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class BotCarManager : MonoBehaviour
    {
        [SerializeField] private Transform endPoint;
        [SerializeField] private Transform startPoint;

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

        private void Update()
        {
            if (_isRaceStarted)
            {
                MoveCar();
            }
        }

        private void OnDisable()
        {
            RacingSignals.Instance.OnRaceStart -= OnRaceStart;
            RacingSignals.Instance.OnRaceEnd -= OnRaceEnd;
            CoreGameSignals.Instance.OnGameStart -= OnGameStart;
        }

        private void OnGameStart()
        {
            switch (SettingsController.Instance.Difficulty)
            {
                case Difficulty.Easy:
                    _duration = 80f;
                    break;
                case Difficulty.Medium:
                    _duration = 65f;
                    break;
                case Difficulty.Hard:
                    _duration = 40f;
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
        
        private void MoveCar()
        {
            if (_elapsedTime < _duration)
            {
                _elapsedTime += Time.deltaTime;
                float t = _elapsedTime / _duration;
                transform.position = Vector3.Lerp(startPoint.position, endPoint.position, t);
            }
            else
            {
                transform.position = endPoint.position;
            }
        }
    }
}
