using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderScript : MonoBehaviour
{
    [SerializeField] Slider VolumeSlider;
    [SerializeField] MusicScript MS;
    public float VolumeControl;
    private bool awakening;


    private void Awake()
    {
        awakening = false;
    }
    private void Start()
    {

        GameObject Slider = GameObject.Find("Music");
        if (Slider == null)
        {
            return;
        }
        MS = Slider.GetComponent<MusicScript>();

        VolumeControl = PlayerPrefs.GetFloat("VolumeControl", VolumeControl);
        if (VolumeControl == 0)
            VolumeControl = .25f;

        PlayerPrefs.SetFloat("VolumeControl", VolumeControl);

        if (VolumeSlider!=null)
        VolumeSlider.value = VolumeControl;
        //MS.musicAudioVolume = VolumeControl;
    }
    private void Update()
    {
        if (awakening)
        {
            if (VolumeControl != VolumeSlider.value)
            {
                VolumeControl = VolumeSlider.value;
                PlayerPrefs.SetFloat("VolumeControl", VolumeControl);
            }
        }
        else
        {
            VolumeControl = PlayerPrefs.GetFloat("VolumeControl", VolumeControl);
            if (VolumeSlider == null)
                return;
            VolumeSlider.value = VolumeControl;
            //MS.musicAudioVolume = VolumeControl;
            if (VolumeSlider.value == VolumeControl)
                awakening = true;
        }
    }

    public void UseCurrent()
    {

    }
}
