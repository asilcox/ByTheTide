using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tdController : MonoBehaviour
{
    [Header("Tide object, should hold all platforms")]
    [SerializeField] GameObject tideObject;
    [Header("Raise direction + rate")]
    [SerializeField] float raiseRate;
    [SerializeField] Vector3 raiseDir;
    [Header("Player interaction bool")]
    [SerializeField] bool canInteract;
    [Header("Raise and lower limits")]
    [SerializeField] Transform maxRaise;
    [SerializeField] Transform minRaise;
    [Header("Current tide state")]
    [SerializeField] tideStates tStates;
    // Update is called once per frame
    void FixedUpdate()
    {
        switch(tStates)
        {
            //Tide is awaiting interaction
            case tideStates.idle:
                {
                    if(canInteract == true)
                    {
                        tStates = tideStates.interact;
                    }
                    break;
                }
                //Tide is awaiting input
            case tideStates.interact:
                {
                    if(Input.GetKey(KeyCode.T))
                    {
                        //Call raise tide function
                        raiseTide();
                    }

                    if(Input.GetKey(KeyCode.G))
                    {
                        //Call lower tide function
                        lowerTide();
                    }

                    //Player exited collider
                    if(canInteract == false)
                    {
                        tStates = tideStates.idle;
                    }
                    break;
                }
        }
    }

    public void raiseTide()
    {
        //Raise tide in raise direction vector, time * rate
        tideObject.transform.Translate(raiseDir * raiseRate * Time.deltaTime);
    }

    public void lowerTide()
    {
        //Lower tide in raise direction vector, time * rate
        tideObject.transform.Translate(-raiseDir * raiseRate * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canInteract = true;
            other.gameObject.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canInteract=false;
            other.gameObject.transform.parent = null;
        }
    }

    public enum tideStates
    {
        idle,
        interact,
    }
}
