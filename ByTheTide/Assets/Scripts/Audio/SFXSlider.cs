using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour
{
    [SerializeField] Slider SoundSlider;
    private float SoundVolume;
    private SoundScript SS;
    private bool Awakening;

    private void Awake()
    {
        Awakening = false;
    }
    private void Start()
    {
        GameObject go_Sound = GameObject.Find("Sound");
        if (go_Sound == null)
            return;

        SoundVolume = PlayerPrefs.GetFloat("SoundVolume", SoundVolume);

        if (SoundVolume == 0)
        {
            SoundVolume = .35f;
            PlayerPrefs.SetFloat("SoundVolume", SoundVolume);
        }

        if (SoundSlider != null)
            SoundSlider = SoundSlider.GetComponent<Slider>();
        SoundVolume = PlayerPrefs.GetFloat("SoundVolume", SoundVolume);

        SS = go_Sound.GetComponent<SoundScript>();

        if (SoundVolume == 0)
            SoundVolume = .25f;

        if (SoundSlider != null)
            SoundSlider.value = SoundVolume;
    }

    private void Update()
    {
        if (Awakening)
        {
            if (SoundVolume != SoundSlider.value)
            {
                SoundVolume = SoundSlider.value;
                PlayerPrefs.SetFloat("SoundVolume", SoundVolume);
            }
        }
        else
        {
            SoundVolume = PlayerPrefs.GetFloat("SoundVolume", SoundVolume);
            if (SoundSlider == null)
                return;
            SoundSlider.value = SoundVolume;
            //MS.musicAudioVolume = VolumeControl;
            if (SoundSlider.value == SoundVolume)
                Awakening = true;
        }
    }
}
