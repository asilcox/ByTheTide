using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Put audio here. Right freakin here
            this.gameObject.SetActive(false);
        }
    }
}
