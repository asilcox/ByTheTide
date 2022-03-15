using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{
    #region Singleton
    // Game Manager Instance
    public static audioManager instance;
    public AudioClip[] clips;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than 1 instance of Game Manager found!");
            Destroy(gameObject);
            return;
        }

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }

        else
        {
            Destroy(gameObject);
        }
        audSource = GetComponent<AudioSource>();
    }
    #endregion

    public AudioMixer _MasterMixer;
    public static audioManager audioMan;
    [SerializeField] public AudioSource audSource;

    public void PlaySound(AudioClip clipName)
    {
        audSource.PlayOneShot(clipName);
    }
    public void PauseSound()
    {
        audSource.PlayOneShot(clips[0]);
    }

    public void JumpSound()
    {
        audSource.PlayOneShot(clips[1]);
    }

    public void RunSound()
    {
        audSource.PlayOneShot(clips[2]);
    }

    public void DeathSound()
    {
        audSource.PlayOneShot(clips[3]);
    }

    public void KeySound()
    {
        audSource.PlayOneShot(clips[4]);
    }

    public void PressureplateSound()
    {
        audSource.PlayOneShot(clips[5]);
    }

    public void tideSound()
    {
        audSource.PlayOneShot(clips[6]);
    }

}

