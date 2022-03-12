using UnityEngine;

public class TideTrigger : MonoBehaviour
{
    [SerializeField]
    TideScript tide;

    private void OnTriggerEnter(Collider col)
    {
        tide.SetHighTide(true);
        Debug.Log("Hello");
    }

    private void OnTriggerExit(Collider col)
    {
        tide.SetHighTide(false);
        Debug.Log("Goodbye");
    }
}
