using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class narrativeTrigger : MonoBehaviour
{
    private narrativeManager nManager;
    public AudioSource aSource;

    private void Awake()
    {
        nManager = GameObject.FindObjectOfType<narrativeManager>();
        aSource = gameObject.GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            nManager.currentState = narrativeManager.playerGameStates.textPop;
            aSource.Play(0);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        nManager.currentState = narrativeManager.playerGameStates.inPlay;
        nManager.updateString();
        Destroy(this.gameObject);
    }


}
