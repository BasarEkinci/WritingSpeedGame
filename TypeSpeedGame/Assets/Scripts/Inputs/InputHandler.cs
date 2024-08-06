using UnityEngine;

namespace Inputs
{
    public class InputHandler : MonoBehaviour
    {
        private string _playerInput = "";
        internal string GetPlayerInput()
        {
            foreach (char c in Input.inputString) 
            { 
                if (c == '\b') 
                { 
                    if (_playerInput.Length != 0) 
                    { 
                        _playerInput = _playerInput.Substring(0, _playerInput.Length - 1);
                    }
                }
                else 
                { 
                    if (Input.inputString != " " && Input.inputString != "\n" && Input.inputString != "\r")
                    {
                        _playerInput += c;
                    } 
                }
            }
            return _playerInput;
        }
        
        internal void ClearPlayerInput()
        {
            _playerInput = "";
        }
    }
}
