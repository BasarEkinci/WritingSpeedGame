namespace Controller
{
    public class PlayerStatsController
    {
        public int CorrectWordCount => _correctWordCount;
        public int WrongWordCount => _wrongWordCount;
        public int TotalWordCount => _totalWordCount;
        public float WordPerMinute => _wordPerMinute;
        
        private int _correctWordCount;
        private int _wrongWordCount;
        private int _totalWordCount;
        private float _wordPerMinute;
        
        public void AddCorrectWord()
        {
            _correctWordCount++;
        }
        
        public void AddWrongWord()
        {
            _wrongWordCount++;
        }
        
        public void CalculateWordPerMinute()
        {
               
        }
        
        public float CalculateWrongWordPercentage()
        {
            float percentage = 100 * _wrongWordCount / _totalWordCount;
            return percentage;
        }
    }
}