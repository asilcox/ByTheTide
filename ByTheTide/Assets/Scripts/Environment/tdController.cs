using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tdController : MonoBehaviour
{
    [SerializeField] GameObject tideObject;
    [SerializeField] float raiseRate;
    [SerializeField] Vector3 raiseDir;
    [SerializeField] bool canInteract;
    [SerializeField] Transform maxRaise;
    [SerializeField] Transform minRaise;
    [SerializeField] tideStates tStates;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(tStates)
        {
            case tideStates.idle:
                {
                    if(canInteract == true)
                    {
                        tStates = tideStates.interact;
                    }
                    break;
                }
            case tideStates.interact:
                {
                    if(Input.GetKey(KeyCode.T))
                    {
                        raiseTide();
                    }

                    if(Input.GetKey(KeyCode.G))
                    {
                        lowerTide();
                    }

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
        tideObject.transform.Translate(raiseDir * raiseRate * Time.deltaTime);
    }

    public void lowerTide()
    {
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
