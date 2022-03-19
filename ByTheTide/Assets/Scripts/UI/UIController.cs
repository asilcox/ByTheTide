using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    #region Singleton
    // UI Instance
    public static UIController instance;

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

    }
    #endregion

    Scene scene;
    string sceneName;

    public bool paused;

    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject gameUI;
    public GameObject controlsPanel;

    private void Start()
    {
        Time.timeScale = 1;
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
        if (sceneName == "mainMenu" || sceneName == "Credits")
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    #region SceneButtons
    public void PausePanel()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
        gameUI.SetActive(false);
    }

    public void SettingsButton()
    {
        settingsMenu.SetActive(true);
    }

    public void ReturnButton()
    {
        if(sceneName == "mainMenu")
        {
            settingsMenu.SetActive(false);
        }
        else
        {
            controlsPanel.SetActive(false);
            settingsMenu.SetActive(false);
            pauseMenu.SetActive(true);
        }
    }
    #endregion
    public void PanelReset()
    {
        if (sceneName != "mainMenu" || sceneName != "Credits")
        {
            pauseMenu.SetActive(false);
            settingsMenu.SetActive(false);
            gameUI.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
            settingsMenu.SetActive(false);
            gameUI.SetActive(false);
        }
    }
    public void MainMenuReset()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        gameUI.SetActive(false);
    }
    public void Pause()
    {
        audioManager.instance.PauseSound();
        paused = !paused;
        if (paused == true)
        {
            PausePanel();
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        if(paused != true)
        {
            PanelReset();
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Restart()
    {
        GameManager.instance.GetComponent<GameManager>().RestartLevel();
        PanelReset();
    }

    public void ControlsPanel()
    {
        controlsPanel.SetActive(true);
    }
}
