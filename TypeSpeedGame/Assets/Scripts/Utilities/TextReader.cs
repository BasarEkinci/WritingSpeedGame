using System;
using System.Collections.Generic;
using System.IO;
using Data.UnityObjects;
using UnityEngine;

namespace Utilities
{
    public class TextReader : MonoBehaviour
    {
        private WordBankSO _wordBankSo;

        private void Awake()
        {
            _wordBankSo = Resources.Load<WordBankSO>($"Data/WordBank");
        }

        private void Start()
        {
            LoadWords("WordDatabaseTR.txt", _wordBankSo.wordBank.turkishWords);
            LoadWords("WordDatabaseEng.txt", _wordBankSo.wordBank.englishWords);
        }

        private void OnApplicationQuit()
        {
            ClearWordLists();
        }

        private void LoadWords(string fileName,List<string> wordList)
        {
            string filePath = Path.Combine("Assets", "Resources/Data", fileName);

            if (File.Exists(filePath))
            {
                string fileContents = File.ReadAllText(filePath);
                string[] words = fileContents.Split(' ');

                foreach (string word in words)
                {
                    var lower = word.ToLower();
                    wordList.Add(lower);
                }
            }           
        }
        
        private void ClearWordLists()
        {
            _wordBankSo.wordBank.turkishWords.Clear();
            _wordBankSo.wordBank.englishWords.Clear();
        }
    }
}