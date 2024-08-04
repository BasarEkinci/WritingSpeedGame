using Extensions;
using UnityEngine.Events;

namespace Signals
{
    public class TypingSignals : MonoSingleton<TypingSignals>
    {
        public UnityAction OnCorrectWord = delegate { };
        public UnityAction OnWrongWord = delegate { };
    }
}