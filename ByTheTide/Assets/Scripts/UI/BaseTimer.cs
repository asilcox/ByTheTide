using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BaseTimer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    public GameObject taPanel;
    public GameObject player;


    private void Start()
    {
       
    }
    void Update()
    {
        if (timerIsRunning) //checks for active timer
        {
            if (timeRemaining > 0) //if value still remains, counts time down
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                FailCheck();
            }
        }
    }

    void FailCheck()
    {
        Cursor.lockState = CursorLockMode.None;
        player.GetComponent<CharacterController>().enabled = false;
        taPanel.SetActive(true);
        Time.timeScale = 0;
    }

    void DisplayTime(float timeToDisplay) //How the text is shown within UI
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void restoreMovement()
    {
        player.GetComponent<CharacterController>().enabled = true;
        Time.timeScale = 1;
    }

    void TimeAttack()
    {
        //Start of Time Attack Specific Functionality
        //switch (timeRemaining)
        //{
        //    case 60:
        //        //first tide raise
        //        break;
        //    case 30:
        //        //second tide raise
        //        break;
        //    case 15:
        //        //second tide raise
        //        break;
        //    default:
        //        break;
        //}
    }
}
