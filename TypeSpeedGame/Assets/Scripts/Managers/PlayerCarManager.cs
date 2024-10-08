﻿using System.Collections.Generic;
using Controller;
using Signals;
using UnityEngine;

namespace Managers
{
    public class PlayerCarManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> tires;
        [SerializeField] private float acceleration;
        
        private CarController _carController;
        private bool _isRaceStarted;
        private bool _isGameStarted;
        private void OnEnable()
        {
            RacingSignals.Instance.OnRaceStart += OnRaceStart;
            RacingSignals.Instance.OnRaceEnd += OnRaceEnd;
            CoreGameSignals.Instance.OnGameStart += OnGameStart;
            CoreGameSignals.Instance.OnGameRestart += OnGameRestart;
            TypingSignals.Instance.OnCorrectWord += OnCorrectWord;
            TypingSignals.Instance.OnWrongWord += OnWrongWord;
        }

        private void Awake()
        {
            _carController = GetComponent<CarController>();
        }

        private void Update()
        {
            if (_isGameStarted && Input.anyKeyDown && !_isRaceStarted)
            {
                RacingSignals.Instance.OnRaceStart?.Invoke();
                _isRaceStarted = true;
            }
            if(_isRaceStarted)
            {
                _carController.AnimatesTires(tires);
            }
            else
            {
                _carController.StopCar();
            }
            
            _carController.MoveCar(Vector3.forward);
        }

        private void OnDisable()
        {
            RacingSignals.Instance.OnRaceStart -= OnRaceStart;
            RacingSignals.Instance.OnRaceEnd -= OnRaceEnd;
            CoreGameSignals.Instance.OnGameStart -= OnGameStart;
            CoreGameSignals.Instance.OnGameRestart -= OnGameRestart;
            TypingSignals.Instance.OnCorrectWord -= OnCorrectWord;
            TypingSignals.Instance.OnWrongWord -= OnWrongWord;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Finish"))
            {
                RacingSignals.Instance.OnRaceEnd?.Invoke();
            }
        }
        private void OnWrongWord()
        {
            _carController.ReduceSpeed(acceleration);
        }

        private void OnCorrectWord()
        {
            _carController.AddSpeed(acceleration);
        }

        private void OnGameRestart()
        {
            _isGameStarted = false;
            _isRaceStarted = false;
        }

        private void OnGameStart()
        {
            _isGameStarted = true;
        }

        private void OnRaceEnd()
        {
            _isRaceStarted = false;
        }

        private void OnRaceStart()
        {
            _carController.AddSpeed(acceleration);
        }
    }
}