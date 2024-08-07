using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Data.UnityObjects;
using Inputs;
using Signals;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controller
{
    public class WordController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerInputText;
        [SerializeField] private TextMeshProUGUI targetWordText;
        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private WordBankSO wordBank;
        
        private List<string> _wordList;
        private string _playerInput;
        private string _targetWord;
        private bool _isCorrect;
        private bool _isGameStarted;

        private void OnEnable()
        {
            CoreGameSignals.Instance.OnGameStart += OnGameStart;
        }

        private void Start()
        {
            _playerInput = "";
        }

        private void OnDisable()
        {
            CoreGameSignals.Instance.OnGameStart -= OnGameStart;
        }
        private void Update()
        {
            if (!_isGameStarted) return;
            _playerInput = inputHandler.GetPlayerInput();
            playerInputText.color = _playerInput.Length > _targetWord.Length ? Color.red : Color.white;
            if(Input.GetKeyDown(KeyCode.Space) && _playerInput != "")
            {
                _isCorrect = CheckWord();
                if (_isCorrect)
                    TypingSignals.Instance.OnCorrectWord?.Invoke();
                else
                    TypingSignals.Instance.OnWrongWord?.Invoke();
                SetTextColor();
                ClearInputArea();
                SetNewTargetWord();
            }
            playerInputText.text = _playerInput;
        }
        
        private void OnGameStart()
        {
            switch (SettingsController.Instance.Language)
            {
                case Language.Turkish:
                    _wordList = wordBank.wordBank.turkishWords;
                    break;
                case Language.English:
                    _wordList = wordBank.wordBank.englishWords;
                    break;
            }
            _targetWord = GetNewTargetWord(_wordList);
            targetWordText.text = _targetWord.ToLower();
            _isGameStarted = true;
        }
        
        private bool CheckWord()
        {
            return _playerInput == _targetWord;
        }
        private string GetNewTargetWord(List<string> wordList)
        {
            _targetWord = wordList[Random.Range(0, wordList.Count)];
            return _targetWord;
        }
        // ReSharper disable Unity.PerformanceAnalysis
        private async void SetNewTargetWord()
        {
            _targetWord = GetNewTargetWord(_wordList);
            await UniTask.Delay(TimeSpan.FromSeconds(0.5), ignoreTimeScale: false);
            targetWordText.text = _targetWord.ToLower();
        }
        private void ClearInputArea()
        {
            _playerInput = "";
            inputHandler.ClearPlayerInput();
            playerInputText.text = _playerInput;
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        private async void SetTextColor()
        {
            targetWordText.color = _isCorrect ? Color.green : Color.red;
            await UniTask.Delay(TimeSpan.FromSeconds(0.5), ignoreTimeScale: false);
            targetWordText.color = Color.white;
        }
    }
}
