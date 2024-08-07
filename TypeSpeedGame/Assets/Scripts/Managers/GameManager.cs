using Signals;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private bool _isTypingStarted;
        private bool _isGameStarted;
        private void OnEnable()
        {
            TypingSignals.Instance.OnCorrectWord += OnCorrectWord;
            TypingSignals.Instance.OnWrongWord += OnWrongWord;
            RacingSignals.Instance.OnRaceStart += OnRaceStart;
            RacingSignals.Instance.OnRaceEnd += OnRaceEnd;
            CoreGameSignals.Instance.OnGameStart += OnGameStart;
            CoreGameSignals.Instance.OnGameRestart += OnGameRestart;
        }

        private void Start()
        {
            _isTypingStarted = false;
        }

        private void Update()
        {
            if(Input.anyKeyDown && !_isTypingStarted && _isGameStarted)
            {
                RacingSignals.Instance.OnRaceStart?.Invoke();
                _isTypingStarted = true;
            }
        }

        private void OnDisable()
        {
            TypingSignals.Instance.OnCorrectWord -= OnCorrectWord;
            TypingSignals.Instance.OnWrongWord -= OnWrongWord;
            RacingSignals.Instance.OnRaceStart -= OnRaceStart;
            RacingSignals.Instance.OnRaceEnd -= OnRaceEnd;
            CoreGameSignals.Instance.OnGameStart -= OnGameStart;
            CoreGameSignals.Instance.OnGameRestart -= OnGameRestart;
        }

        private void OnGameRestart()
        {
            _isGameStarted = false;
            _isTypingStarted = false;
        }

        private void OnGameStart()
        {
            _isGameStarted = true;
        }

        private void OnRaceEnd()
        {
            PlayerStatsController.Instance.StopCalculateTheTime();
            PlayerStatsController.Instance.CalculateWordPerMinute();
        }

        private void OnRaceStart()
        {
            PlayerStatsController.Instance.StartCalculateTheTime();
        }

        private void OnCorrectWord()
        {
            PlayerStatsController.Instance.AddCorrectWord();
        }
        
        private void OnWrongWord()
        {
            PlayerStatsController.Instance.AddWrongWord();
        }
    }
}