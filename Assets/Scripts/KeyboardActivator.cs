using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using TMPro;

public class KeyboardActivator : MonoBehaviour
{
    private TouchScreenKeyboard _overlayKeyboard;


    public string _keyboardInput;


    public void OpenKeyboard()
    {

        _overlayKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);

        _overlayKeyboard.characterLimit = 4;

    }
    private void Update()
    {
        if (_overlayKeyboard != null)
        {
            _keyboardInput = _overlayKeyboard.text;

        }
    }
}
