using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicVolume : MonoBehaviour
{
    public Slider sliderVolume;
    public float sliderVolumeValue;
    public Image imageMuted;

    void Start()
    {
        sliderVolume.value = PlayerPrefs.GetFloat("audioVolume", 0.5f);
        AudioListener.volume = sliderVolume.value;
        CheckIfMuted();
    }

    public void ChangeVolumeSlider(float valueV)
    {
        sliderVolumeValue = valueV;
        PlayerPrefs.SetFloat("audioVolume", sliderVolumeValue);
        AudioListener.volume = sliderVolume.value;
        CheckIfMuted();
    }

    public void CheckIfMuted()
    {
        if (sliderVolumeValue == 0)
        {
            imageMuted.enabled = true;
        }
        else
        {
            imageMuted.enabled = false;
        }
    }
}
