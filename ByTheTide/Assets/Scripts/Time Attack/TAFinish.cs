using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAFinish : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject player;

    void WinCheck()
    {
        Cursor.lockState = CursorLockMode.None;
        player.GetComponent<CharacterController>().enabled = false;
        Time.timeScale = 0;
        winPanel.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            WinCheck();
        }
    }
}
