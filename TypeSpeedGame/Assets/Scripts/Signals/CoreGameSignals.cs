using Extensions;
using UnityEngine.Events;

namespace Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction OnGameStart = delegate { };
        public UnityAction OnGameEnd = delegate { };
        public UnityAction OnGameRestart = delegate { };
        public UnityAction OnGameWin = delegate { };
        public UnityAction OnGameLose = delegate { };
    }
}