using System;
using Extensions;
using UnityEngine;

namespace Utilities
{
    public class PlayerStatsController : MonoSingleton<PlayerStatsController>
    {
        public int TotalWordCount => _totalWordCount;
        public float CompleteTime => _completeTime;
        public int CorrectWordCount => _correctWordCount;
        public int WrongWordCount => _wrongWordCount;
        public float WordPerMinute => _wordPerMinute;
        
        private int _totalWordCount;
        private float _completeTime;
        private int _correctWordCount;
        private int _wrongWordCount;
        private float _wordPerMinute;
        private float _startTime;
        
        public void AddWrongWord()
        {
            _totalWordCount++;
            _wrongWordCount++;
        }
        
        public void AddCorrectWord()
        {
            _totalWordCount++;
            _correctWordCount++;
        }
        
        public void CalculateWordPerMinute() => _wordPerMinute = 60 * _totalWordCount / _completeTime;
        public void StartCalculateTheTime() => _startTime = Time.time;
        public void StopCalculateTheTime() => _completeTime = Time.time - _startTime;
        
    }
}
