using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationEffects : MonoBehaviour
{
    [SerializeField] Vector3 rotationDir;
    [SerializeField] float rotationSpeed;

    //private void OnTriggerStay(Collider other)
    //{
    //    if(other.gameObject.tag == "Player")
    //    {
    //        other.gameObject.transform.SetParent(this.gameObject.transform);
    //        other.gameObject.transform.localScale.Set(1,1,1);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        other.gameObject.transform.localScale.Set(1, 1, 1);
    //        other.gameObject.transform.SetParent(null);
    //    }

    //}

    private void FixedUpdate()
    {
        transform.Rotate(rotationDir, rotationSpeed);
    }
}
