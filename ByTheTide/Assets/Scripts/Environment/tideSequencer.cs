using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tideSequencer : MonoBehaviour
{
    [SerializeField] Animator canvasAnim;
    [SerializeField] public tideStatus tideStateStatus;
    [SerializeField] GameObject[] tideObjs;
    [SerializeField] public int identifier;
    [SerializeField] GameObject[] rainObjects;
    private DayNightController dnController;
    private GameObject player;
    [SerializeField] characterMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dnController = GameObject.FindObjectOfType<DayNightController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(tideStateStatus)
        {
            case tideStatus.tideOneAct:
                {
                    identifier = 1;
                    tideObjs[0].SetActive(true);
                    tideObjs[1].SetActive(false);
                    break;
                }
                case tideStatus.tideTwoAct:
                {
                    identifier = 2;
                    tideObjs[0].SetActive(false);
                    tideObjs[1].SetActive(true);
                    break;
                }
        }
    }

    void transition()
    {
        dnController.daySpeedMultiplier = 0;
        canvasAnim.SetTrigger("loading");
    }

    public void switchToOne()
    {
        transition();
        player.transform.SetParent(null);
        tideStateStatus = tideStatus.tideOneAct;
    }

    public void switchToTwo()
    {
        transition();
        foreach (GameObject gObj in rainObjects)
        {
            gObj.SetActive(false);
        }
        player.transform.SetParent(null);
        playerMovement.SetMovementSpeed(5);
        playerMovement.SetJumpHeight(2);
        tideStateStatus = tideStatus.tideTwoAct; ;
    }
    public enum tideStatus
    {
        tideOneAct,
        tideTwoAct,
    }
}
