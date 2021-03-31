using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quality : MonoBehaviour
{
    [Header("References")]
    [Space]
    public Dropdown dropdown;

    [Header("Integers")]
    [Space]
    public int quality = 3;

    void Start()
    {
        quality = PlayerPrefs.GetInt("QualityNumber", quality);
        dropdown.value = quality;
        AdjustQuality();
    }

    public void AdjustQuality()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numeroDeCalidad", dropdown.value);
        quality = dropdown.value;
    }
}
