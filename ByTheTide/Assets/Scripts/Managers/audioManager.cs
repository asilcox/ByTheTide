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
    [SerializeField] AudioSource audSource;

    public void PlaySound(AudioClip clipName)
    {
        audSource.PlayOneShot(clipName);
    }
    public void PauseSound()
    {
        audSource.PlayOneShot(clips[0]);
    }
}

