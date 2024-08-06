using Extensions;
using UnityEngine.Events;

namespace Signals
{
    public class RacingSignals : MonoSingleton<RacingSignals>
    {
        public UnityAction OnRaceStart = delegate { };
        public UnityAction OnRaceEnd = delegate { };
    }
}