using Controller;
using UnityEngine;

namespace UIs
{
    public class SettingsButtons : MonoBehaviour
    {
        [SerializeField] private SettingsController settingsController;
        
        public void SetMusic(bool isMusicOn)
        {
            settingsController.SetMusic(isMusicOn);
        }
        
        public void SetSwitchSound(bool isSwitchSoundOn)
        {
            settingsController.SetSwitchSound(isSwitchSoundOn);
        }
        
        public void SetDifficulty(int difficulty)
        {
            settingsController.SetDifficulty((Difficulty)difficulty);
        }
        
        public void SetLanguage(int language)
        {
            settingsController.SetLanguage((Language)language);
        }
        
    }
}