using Signals;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        public void PlayButton()
        {
            CoreGameSignals.Instance.OnGameStart?.Invoke();
        }
    }
}