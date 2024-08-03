using Data.ValueObjects;
using UnityEngine;

namespace Data.UnityObjects
{
    [CreateAssetMenu(fileName = "WordBank", menuName = "WordBank",order = 1)]
    public class WordBankSO : ScriptableObject
    {
        public WordBank wordBank;
    }
}