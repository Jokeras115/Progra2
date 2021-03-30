using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [Header("References")]
    [Space]
    public Slider slider;
    public Image imagenMute;

    [Header("Floats")]
    [Space]
    public float sliderValue;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("AudioVolume", 50.0f);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();
    }

    public void ChangeSlider(float valor)
    {

        sliderValue = valor;
        PlayerPrefs.SetFloat("AudioVolume", sliderValue);
        AudioListener.volume = slider.value;
       RevisarSiEstoyMute();
        
    }

     public void RevisarSiEstoyMute()
     {
        if(sliderValue == 0)
        {
            imagenMute.enabled = true;
        }

        else
        {
            imagenMute.enabled = false;
        }

    }

}
