using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUBmanger : MonoBehaviour
{
    private int HighLevel;
    [SerializeField] private Animator anim;

    private void Start()
    {
        Debug.Log(HighLevel);
        anim = anim.GetComponent<Animator>();
        HighLevel = PlayerPrefs.GetInt("HighLevel");
        anim.SetInteger("HighLevel", HighLevel);
    }
}
