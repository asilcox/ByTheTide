using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseLowerPlatform : MonoBehaviour
{
    public bool LoweringPlatform;
    public float PlatformTimer;
    [SerializeField] GameObject Water;
    private Vector3 TideHeight;
    private bool inRange, inRangeStay;
    private float LowerTimer;
    private Rigidbody rb;
    private bool RaisePlatformBack;

    private void Start()
    {
        TideHeight = transform.position;
        rb = GetComponent<Rigidbody>();
        LowerTimer = PlatformTimer;
    }

    private void Update()
    {
        if (!LoweringPlatform)
        {
            TideHeight.y = Water.transform.position.y;
            transform.position = new Vector3(TideHeight.x, TideHeight.y, TideHeight.z);
        }
        else
        {
            if (inRange)
            {
                Debug.Log("in range called");
                LowerTimer -= Time.deltaTime;
                if (LowerTimer < 0)
                {
                    Debug.Log("timer is less than 0");
                    rb.useGravity = true;
                    Invoke("WaitTimer", 5f);
                }
            }
            if (RaisePlatformBack && !inRangeStay)
            {
                rb.useGravity = false;
                transform.position = Vector3.Lerp(transform.position, TideHeight, Time.deltaTime*2);
                StartCoroutine("WaitTimerSet");
            }
        }
    }

    private void WaitTimer()
    {
        RaisePlatformBack = true;
        inRange = false;
    }

    private IEnumerator WaitTimerSet()
    {
        yield return new WaitForSeconds(2.5f);
        inRange = false;
        RaisePlatformBack = false;
        LowerTimer = PlatformTimer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "playerObj")
        {
            inRange = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "playerObj")
        {
            inRangeStay = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "playerObj")
        {
            inRangeStay = false;
        }
    }
}
