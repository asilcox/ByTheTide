using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{
    private AudioSource audSource;

    [SerializeField] private AudioClip MouseHover, MouseClick, BackButtonAudio;
    [SerializeField] private GameObject AM;

    private void Start()
    {
        audSource = GetComponent<AudioSource>();
        if (AM != null)
            gameObject.SetActive(false);
    }

    public void PlayMouseHover()
    {
        audSource.PlayOneShot(MouseHover);
    }

    public void PlayMouseClick()
    {
        audSource.PlayOneShot(MouseClick);
    }
    public void PlayBackButton()
    {
        audSource.PlayOneShot(BackButtonAudio);
    }
}