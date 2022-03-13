using UnityEngine;
using System.Collections;


public class TideTrigger : MonoBehaviour
{
    [SerializeField]
    TideScript tide;
    private AudioSource AS;

    private bool canPlay = true;

    private void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        tide.SetHighTide(true);

        if (other.gameObject.tag == "Player")
            AS.Play();
        canPlay = false;
        StopAllCoroutines();
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(.6f);
        canPlay = true;
    }

    private void OnTriggerExit(Collider col)
    {
        tide.SetHighTide(false);
        StartCoroutine("Reset");
    }
}
