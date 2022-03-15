using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tideSequenceTrigger : MonoBehaviour
{
    private tideSequencer tSeq;
    // Start is called before the first frame update
    void Start()
    {
        tSeq = GetComponentInParent<tideSequencer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(tSeq.identifier == 1)
            {
                tSeq.switchToTwo();
            }
            else
            {
                tSeq.switchToOne();
            }
        }
    }
}
