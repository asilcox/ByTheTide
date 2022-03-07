using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AmbienceScript : MonoBehaviour
{
    public static AmbienceScript Instance
    {
        get
        {
            if (instance != null)
                return instance;

            instance = FindObjectOfType<AmbienceScript>();

            return instance;
        }
    }

    protected static AmbienceScript instance;
    protected bool TransferAmbience;

    protected AmbienceScript oldInstance = null;

    [SerializeField] Slider sliderVolume;
    [SerializeField] AmbienceSlider SS;
    protected AudioSource AmbienceAudio;

    protected string AmbienceAudioName, AmbienceAudioNameNew, AmbienceAudioLoop, AmbienceAudioIntro;

    public float AmbienceAudioVolume;

    [SerializeField] AudioClip LoopAmbience;

    private float newAmbienceVolume, VolumeControl;
    public float AmbienceTimeSwitch;

    public bool PlayAmbienceOnAwake = true;

    public bool isPlying = false;

    protected Stack<AudioClip> AmbienceStack = new Stack<AudioClip>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            if (Instance.LoopAmbience == LoopAmbience)
            {
                TransferAmbience = true;
            }

            oldInstance = Instance;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);

        AmbienceAudio = gameObject.AddComponent<AudioSource>();

        if (PlayAmbienceOnAwake)
        {
            AmbienceAudio.time = 0f;
            AmbienceAudio.Play();
        }
    }

    private void Start()
    {
        if (oldInstance != null)
        {
            if (TransferAmbience)
                AmbienceAudio.timeSamples = oldInstance.AmbienceAudio.timeSamples;
            oldInstance.StopAllCoroutines();
            Destroy(oldInstance.gameObject);
        }
        AmbienceAudio = AmbienceAudio.GetComponent<AudioSource>();

        VolumeControl = PlayerPrefs.GetFloat("VolumeControl", VolumeControl);

        AmbienceAudio.clip = LoopAmbience;
        AmbienceAudio.Play();

        AmbienceAudio.loop = true;
    }



    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string SceneName = currentScene.name;

        GameObject Slider = GameObject.Find("AmbienceSlider");
        if (Slider == null)
        {
            AmbienceAudioVolume = VolumeControl;
            AmbienceAudio.volume = VolumeControl;
            return;
        }

        SS = Slider.GetComponent<AmbienceSlider>();
        SS.UseCurrent();

        if (SS != null)
        {
            AmbienceAudio.volume = SS.VolumeControl;
        }
    }
}
