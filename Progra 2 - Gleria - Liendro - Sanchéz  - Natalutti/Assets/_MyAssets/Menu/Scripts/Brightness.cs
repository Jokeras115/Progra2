using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brightness : MonoBehaviour
{
    #region Variables
    [Header("References")]
    [Space]
    public Slider slider;
    public Image brightnessPanel;

    [Header("Floats")]
    [Space]
    public float sliderValue;
    #endregion

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("brillo", 0.5f);

        brightnessPanel.color = new Color(brightnessPanel.color.r, brightnessPanel.color.g, brightnessPanel.color.b, slider.value);
    }

    public void ChangeSlider(float value)

    {
        sliderValue = value;
        PlayerPrefs.SetFloat("Brightness", sliderValue);
        brightnessPanel.color = new Color(brightnessPanel.color.r, brightnessPanel.color.g, brightnessPanel.color.b, slider.value);
    }

}
