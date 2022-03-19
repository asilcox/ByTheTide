using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainPlayerFollow : MonoBehaviour
{
    [SerializeField] GameObject playerObj;
    [SerializeField] Vector3 followAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerObj.transform.position.x, followAngle.y, playerObj.transform.position.x);
    }
}
