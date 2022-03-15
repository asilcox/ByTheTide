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

    private int FirstPlaythrough;

    void Start()
    {
        FirstPlaythrough = PlayerPrefs.GetInt("FirstTime", FirstPlaythrough);

        if (FirstPlaythrough == 0)
        {
            masterSlider.value = 0.75f;
            PlayerPrefs.SetFloat("masterVol", masterSlider.value);
            bgmSlider.value = 0.75f;
            PlayerPrefs.SetFloat("bgmVolume", bgmSlider.value);
            sfxSlider.value = 0.75f;
            PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);

            PlayerPrefs.SetInt("FirstTime", 1);
        }
        else
        {
            sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
            bgmSlider.value = PlayerPrefs.GetFloat("bgmVolume");
            masterSlider.value = PlayerPrefs.GetFloat("masterVol");
        }
    }

    public void SetMasterVolume(float sliderValue)
    {
        master.SetFloat("masterVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("masterVol", sliderValue);
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
