using System;
using Extensions;
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
    public class SettingsController : MonoSingleton<SettingsController>
    {
        public bool IsMusicOn => _isMusicOn;
        public bool IsSwitchSoundOn => _isSwitchSoundOn;
        public Difficulty Difficulty => _difficulty;
        public Language Language => _language;
        
        
        private bool _isMusicOn;
        private bool _isSwitchSoundOn;
        private Difficulty _difficulty;
        private Language _language;

        internal void SetMusic(bool isMusicOn)
        {
            _isMusicOn = isMusicOn;
        }
        
        internal void SetSwitchSound(bool isSwitchSoundOn)
        {
            _isSwitchSoundOn = isSwitchSoundOn;
        }
        
        internal void SetDifficulty(Difficulty difficulty)
        {
            _difficulty = difficulty;
        }
        
        internal void SetLanguage(Language language)
        {
            _language = language;
        }
    }
}