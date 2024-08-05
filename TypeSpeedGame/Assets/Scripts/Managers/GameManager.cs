using Controller;
using Signals;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [FormerlySerializedAs("inputHandler")] [FormerlySerializedAs("inputChecker")] [SerializeField] private WordController wordController;
        
        private bool _isGameStarted = false;
        private void OnEnable()
        {
            CoreGameSignals.Instance.OnGameStart += OnGameStart;
            CoreGameSignals.Instance.OnGameEnd += OnGameEnd;
            CoreGameSignals.Instance.OnGameRestart += OnGameRestart;
        }

        private void Update()
        {
            if (_isGameStarted)
            {
                wordController.SetPlayerInput();
            }
        }

        private void OnDisable()
        {
            CoreGameSignals.Instance.OnGameStart -= OnGameStart;
            CoreGameSignals.Instance.OnGameEnd -= OnGameEnd;
            CoreGameSignals.Instance.OnGameRestart -= OnGameRestart;
        }

        private void OnGameRestart()
        {
            
        }

        private void OnGameEnd()
        {
            
        }

        private void OnGameStart()
        {
            _isGameStarted = true;
            wordController.SetInitialWord();
        }
    }
}