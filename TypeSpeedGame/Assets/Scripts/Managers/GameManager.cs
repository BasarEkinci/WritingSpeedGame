using System;
using Controller;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Language: " + SettingsController.Instance.Language);
                Debug.Log("Difficulty: " + SettingsController.Instance.Difficulty);
                Debug.Log("IsMusicOn: " + SettingsController.Instance.IsMusicOn);
                Debug.Log("IsSwitchSoundOn: " + SettingsController.Instance.IsSwitchSoundOn);
            }
        }
    }
}