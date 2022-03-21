using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItemScript : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 7f);
    }
}
