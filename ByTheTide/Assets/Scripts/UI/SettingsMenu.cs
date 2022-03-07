using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    #region References
    public AudioMixer master;
    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    #endregion
    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVol", 0.75f);
        bgmSlider.value = PlayerPrefs.GetFloat("bgmVolume", 0.75f);
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume", 0.75f);
    }

    public void SetMasterVolume(float sliderValue)
    {
        master.SetFloat("masterVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("", sliderValue);
    }

    public void SetBGMVolume(float sliderValue)
    {
        master.SetFloat("bgmVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("bgmVolume", sliderValue);
    }

    public void SetSFXVolume(float sliderValue)
    {
        master.SetFloat("sfxVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("sfxVolume", sliderValue);
    }

    public void SetFullscreen(bool isFullscreen) // Fullscreen On/Off
    {
        Screen.fullScreen = isFullscreen;
    }
}
