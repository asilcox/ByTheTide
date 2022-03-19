using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class narrativeTrigger : MonoBehaviour
{
    private narrativeManager nManager;


    private void Awake()
    {
        nManager = GameObject.FindObjectOfType<narrativeManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            nManager.currentState = narrativeManager.playerGameStates.textPop;

        }
    }

    public void OnTriggerExit(Collider other)
    {
        nManager.currentState = narrativeManager.playerGameStates.inPlay;
        nManager.updateString();
        Destroy(this.gameObject);
    }


}
