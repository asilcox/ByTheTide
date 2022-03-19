using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAStart : MonoBehaviour
{
    public GameObject player;
    public bool activeTA = false;

    private void Awake()
    {
        player.GetComponent<CharacterController>().enabled = false;
        Time.timeScale = 0;
    }

    public void StartTA()
    {
        player.GetComponent<CharacterController>().enabled = true;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Destroy(gameObject);
    }

    public void HubReturn()
    {
        player.GetComponent<CharacterController>().enabled = true;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
