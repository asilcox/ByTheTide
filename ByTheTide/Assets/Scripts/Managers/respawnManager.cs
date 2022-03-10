using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnManager : MonoBehaviour
{
    private playerStats pStates;

    private void Start()
    {
        pStates = GetComponent<playerStats>();
    }
    public void resetPlayer(Transform lastObj, GameObject playerObject)
    {
        //Turns off character controller
        playerObject.GetComponent<CharacterController>().enabled = false;
        //Moves character position to previosly interacted with position
        playerObject.transform.position = lastObj.transform.position + new Vector3(0,1,0);
        //Turns on character controller
        playerObject.GetComponent<CharacterController>().enabled = true;

        pStates.loseLife();
    }
}
