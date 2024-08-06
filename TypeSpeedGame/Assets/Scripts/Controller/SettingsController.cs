using UnityEngine;

namespace Controller
{
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard,
        AgainstYourself
    }
    public enum Language
    {
        Turkish,
        English
    }
    public class SettingsController : MonoBehaviour
    {
        private bool _isMusicOn;
        private bool _isSwitchSoundOn;
        private Difficulty _difficulty;
        private Language _language;
    }
}