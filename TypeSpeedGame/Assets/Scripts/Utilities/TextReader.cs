using System.Collections.Generic;
using System.IO;
using Data.UnityObjects;
using UnityEngine;

namespace Utilities
{
    public class TextReader : MonoBehaviour
    {
        [SerializeField] private WordBankSO wordBankSo;
        private void Start()
        {
            LoadWords("WordDatabaseTR.txt", wordBankSo.wordBank.turkishWords);
            LoadWords("WordDatabaseEng.txt", wordBankSo.wordBank.englishWords);
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
            wordBankSo.wordBank.turkishWords.Clear();
            wordBankSo.wordBank.englishWords.Clear();
        }
    }
}