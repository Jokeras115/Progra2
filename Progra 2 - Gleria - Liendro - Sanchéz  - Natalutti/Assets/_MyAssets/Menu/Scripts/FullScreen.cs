using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreen : MonoBehaviour
{
    public Toggle toggle;
    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

    }

    void Update()
    {

    }
    public void ActivarPantallaCompleta(bool PantallaCompleta)

    {

        Screen.fullScreen = PantallaCompleta;
    }
}
