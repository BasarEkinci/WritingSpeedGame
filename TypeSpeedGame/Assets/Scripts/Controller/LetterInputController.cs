using System;
using Cysharp.Threading.Tasks;
using Data.UnityObjects;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controller
{
    public class LetterInputController : MonoBehaviour
    {
        [SerializeField] private TMP_Text letterText;
        [SerializeField] private TextMeshProUGUI currentWordText;
        [SerializeField] private WordBankSO wordBank;
        private string _currentLetter;
        private string _currentWord = "target";
        private bool _isCorrect;
        private void Update()
        {
            if(Input.anyKeyDown)
            {
                foreach (char c in Input.inputString)
                {
                    Debug.Log("Game Started");
                    if (c == '\b')
                    {
                        if (_currentLetter.Length != 0)
                        {
                            _currentLetter = _currentLetter.Substring(0, _currentLetter.Length - 1);
                        }
                    }
                    else
                    {
                        if (Input.inputString != " " && Input.inputString != "\n" && Input.inputString != "\r")
                        {
                            _currentLetter += c;
                        }
                        Debug.Log(c);
                        CheckWord();
                    }

                    letterText.text = _currentLetter;
                }

            }
        }

        private async void CheckWord()
        {
            _isCorrect = true;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (_currentLetter.Length > _currentWord.Length)
                {
                    _isCorrect = false;
                }
                else if (_currentLetter.Length < _currentWord.Length)
                {
                    _isCorrect = false;
                }
                else
                {
                    for (int i = 0; i < _currentWord.Length; i++)
                    {
                        if (_currentLetter[i] != _currentWord[i])
                        {
                            _isCorrect = false;
                        }
                    }
                }
                
                if (_isCorrect)
                {
                    currentWordText.color = Color.green;
                }
                else
                {
                    currentWordText.color = Color.red;
                }
                _currentLetter = "";
                await UniTask.Delay(TimeSpan.FromSeconds(0.5), ignoreTimeScale: false);
                _isCorrect = true;
                _currentWord = wordBank.wordBank.turkishWords[Random.Range(0, wordBank.wordBank.turkishWords.Count)];
                currentWordText.color = Color.white;
                currentWordText.text = _currentWord;
                
            }
        }
    }
}
