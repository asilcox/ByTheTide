using UnityEngine;

public class tdController : MonoBehaviour
{
    private UIManager uManager;
    [Header("Tide object, should hold all platforms")]
    [SerializeField] GameObject tideObject;
    [Header("Raise direction + rate")]
    [SerializeField] float raiseRate;
    [SerializeField] Vector3 raiseDir;
    [Header("Player interaction bool")]
    [SerializeField] bool canInteract;
    [Header("Raise and lower limits")]
    [SerializeField] Vector3 maxRaise;
    [SerializeField] Vector3 minRaise;
    [Header("Current tide state")]
    [SerializeField] tideStates tStates;
    [Header("Get day night sys")]
    [SerializeField] DayNightController dnController;

    [SerializeField] ParticleSystem partiSys;

    private void Start()
    {
        uManager = GameObject.FindObjectOfType<UIManager>();
        dnController = GameObject.FindObjectOfType<DayNightController>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        switch (tStates)
        {
            //Tide is awaiting interaction
            case tideStates.idle:
                {
                    partiSys.enableEmission = false;
                    if (canInteract == true)
                    {
                        tStates = tideStates.interact;

                    }
                    break;
                }
            //Tide is awaiting input
            case tideStates.interact:
                {
                    dnController.daySpeedMultiplier = 0;
                    if (Input.GetKey(KeyCode.T))
                    {
                        //Call raise tide function
                        if (audioManager.instance.audSource.isPlaying == false)
                        {
                            audioManager.instance.tideSound();
                        }
                        else
                        {

                        }
                        raiseTide();
                    }

                    if (Input.GetKey(KeyCode.G))
                    {
                        //Call lower tide function
                        if (audioManager.instance.audSource.isPlaying == false)
                        {
                            audioManager.instance.tideSound();
                        }
                        else
                        {

                        }
                        lowerTide();
                    }

                    //Player exited collider
                    if (canInteract == false)
                    {
                        tStates = tideStates.idle;
                    }
                    break;
                }
        }
    }

    public void raiseTide()
    {
        partiSys.enableEmission = true;
        if (tideObject.transform.position.y >= maxRaise.y)
        {
            Debug.Log("Max height reached");
        }
        else
        {
            //Raise tide in raise direction vector, time * rated
            dnController.daySpeedMultiplier = 0.35f;
            tideObject.transform.Translate(raiseDir * raiseRate * Time.deltaTime);
        }

    }

    public void lowerTide()
    {
        partiSys.enableEmission = true;
        if (tideObject.transform.position.y <= minRaise.y)
        {
            Debug.Log("Min height reached");
        }
        else
        {
            //Lower tide in raise direction vector, time * rate
            dnController.daySpeedMultiplier = -0.35f;
            tideObject.transform.Translate(-raiseDir * raiseRate * Time.deltaTime);
        }

    }

    public void SetDaySpeed(float ds)
    {
        dnController.daySpeedMultiplier = ds;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canInteract = true;
            other.gameObject.transform.parent = this.transform;
            uManager.triggerControls(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dnController.daySpeedMultiplier = 0;
            canInteract = false;
            other.gameObject.transform.parent = null;
            uManager.triggerControls(false);
        }
    }

    public enum tideStates
    {
        idle,
        interact,
    }
}
