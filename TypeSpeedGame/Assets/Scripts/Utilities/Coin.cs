using UnityEngine;

namespace Utilities
{
    public class Coin : MonoBehaviour
    {
        public int CurrentCoin => _currentCoin;
        
        private int _currentCoin;
        
        internal void AddCoin(int amount)
        {
            _currentCoin += amount;
        }
        
        internal void RemoveCoin(int amount)
        {
            _currentCoin -= amount;
        }
    }
}