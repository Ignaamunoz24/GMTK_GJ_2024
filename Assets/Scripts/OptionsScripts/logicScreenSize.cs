using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicScreenSize : MonoBehaviour
{
    public Toggle toggleFS;

    void Start()
    {
        if (Screen.fullScreen)
        {
            toggleFS.isOn = true;
        }
        else
        {
            toggleFS.isOn = false;
        }
    }

    public void ActivateFullscreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }
}
