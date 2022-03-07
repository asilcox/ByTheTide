using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MusicScript : MonoBehaviour
{
    public static MusicScript Instance
    {
        get
        {
            if (instance != null)
                return instance;

            instance = FindObjectOfType<MusicScript>();

            return instance;
        }
    }

    protected static MusicScript instance;
    protected bool TransferMusic;

    protected MusicScript oldInstance = null;

    [SerializeField] Slider sliderVolume;
    [SerializeField] SliderScript SS;
    protected AudioSource musicAudio;

    protected string MusicAudioName, MusicAudioNameNew, MusicAudioLoop, MusicAudioIntro;

    public float musicAudioVolume;

    [SerializeField] AudioClip introMusic, LoopMusic;

    private float newMusicVolume, VolumeControl;
    public float MusicTimeSwitch;

    public bool PlayMusicOnAwake = true;

    public bool isPlying = false;

    protected Stack<AudioClip> MusicStack = new Stack<AudioClip>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
                if (Instance.LoopMusic == LoopMusic || Instance.introMusic == introMusic)
                {
                    TransferMusic = true;
                }

            oldInstance = Instance;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);

        musicAudio = gameObject.AddComponent<AudioSource>();

        if (PlayMusicOnAwake)
        {
            musicAudio.time = 0f;
            musicAudio.Play();
        }
    }

    private void Start()
    {
        if (oldInstance != null)
        {
            if (TransferMusic)
                musicAudio.timeSamples = oldInstance.musicAudio.timeSamples;
            oldInstance.StopAllCoroutines();
            Destroy(oldInstance.gameObject);
        }
        musicAudio = musicAudio.GetComponent<AudioSource>();

        VolumeControl = PlayerPrefs.GetFloat("VolumeControl", VolumeControl);

        StartCoroutine("MusicSwitchOtherScenesWait");
        musicAudio.clip = introMusic;
        musicAudio.Play();

        musicAudio.loop = true;
    }



    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string SceneName = currentScene.name;

        GameObject Slider = GameObject.Find("MusicSlider");
        if (Slider == null)
        {
            musicAudioVolume = VolumeControl;
            musicAudio.volume = VolumeControl;
            return;
        }

        SS = Slider.GetComponent<SliderScript>();
        SS.UseCurrent();

        if (SS != null)
        {
            musicAudio.volume = SS.VolumeControl;
            // musicAudioVolume = SS.VolumeControl;
        }
    }


    IEnumerator MusicSwitchOtherScenesWait()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string SceneName = currentScene.name;

        yield return new WaitForSecondsRealtime(MusicTimeSwitch);
        musicAudio.clip = LoopMusic;

        musicAudio.Play();
        musicAudio.loop = true;
    }
}

