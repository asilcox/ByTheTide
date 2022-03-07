using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsMenu;

    void Start()
    {
        settingsMenu = GameObject.FindGameObjectWithTag("MainUI");
    }

    public void Settings()
    {
        settingsMenu.GetComponent<UIController>().SettingsButton();
    }

    public void StartGame()
    {
        settingsMenu.GetComponent<UIController>().gameUI.SetActive(true);
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
