using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class logicQuality : MonoBehaviour
{
    public TMP_Dropdown dropdownQuality;
    public int quality;

    void Start()
    {
        quality = PlayerPrefs.GetInt("qualityNumber", 2);
        dropdownQuality.value = quality;
        AdjustQuality();
    }

    public void AdjustQuality()
    {
        QualitySettings.SetQualityLevel(dropdownQuality.value);
        PlayerPrefs.SetInt("qualityNumber", dropdownQuality.value);
        quality = dropdownQuality.value;
    }

}
