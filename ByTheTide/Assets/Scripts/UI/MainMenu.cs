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
        //settingsMenu.GetComponent<UIController>().gameUI.SetActive(true);
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
