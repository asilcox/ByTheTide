using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsMenu;

    void Start()
    {
        settingsMenu = GameObject.FindGameObjectWithTag("MainUI");
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Settings()
    {
        settingsMenu.GetComponent<UIController>().SettingsButton();
    }

    public void StartGame()
    {
        float soundVol = PlayerPrefs.GetFloat("sfxVolume");
        float musicVol = PlayerPrefs.GetFloat("bgmVolume");
        float masterVol = PlayerPrefs.GetFloat("masterVol");

        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetFloat("bgmVolume", musicVol);
        PlayerPrefs.SetFloat("sfxVolume", soundVol);
        PlayerPrefs.SetFloat("masterVol", masterVol);

        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Controls()
    {
        settingsMenu.GetComponent<UIController>().ControlsPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
