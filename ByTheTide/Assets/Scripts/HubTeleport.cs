using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubTeleport : MonoBehaviour
{
    public GameObject player;
    public GameObject nextBoat;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player inside Trigger");
        //nextBoat.SetActive(true);
        //player.transform.position = nextBoat.transform.position;
        //gameObject.SetActive(false);
        if(audioManager.instance!=null)
        audioManager.instance.BoatSound();
        //Turns off character controller
        player.GetComponent<CharacterController>().enabled = false;
        //Moves character position to previosly interacted with position
        player.transform.position = nextBoat.transform.position + new Vector3(0, 1, 0);
        //Turns on character controller
        player.GetComponent<CharacterController>().enabled = true;
    }
}
