using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    private float SoundVolume, curVolume;
    [SerializeField] AudioSource[] AS;

    private void Start()
    {
        SoundVolume = PlayerPrefs.GetFloat("SoundVolume", SoundVolume);
        curVolume = SoundVolume;
        for (int i = 0; i < AS.Length; i++)
        {
            AS[i] = AS[i].GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        SoundVolume = PlayerPrefs.GetFloat("SoundVolume", SoundVolume);
        for (int i = 0; i < AS.Length; i++)
            {
            AS[i].volume = SoundVolume;
                curVolume = SoundVolume;
            }
        
    }
}
