using UnityEngine;

public class TideTrigger : MonoBehaviour
{
    [SerializeField]
    tdController tide;

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Contact with Pressure Plate");
    }

    private void OnTriggerExit(Collider col)
    {
        Debug.Log("Lost contact with Pressure Plate");
    }
}
