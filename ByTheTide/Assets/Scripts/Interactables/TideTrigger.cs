using UnityEngine;

public class TideTrigger : MonoBehaviour
{
    [SerializeField]
    tdController tide;

    private void OnTriggerEnter(Collider col)
    {
        tide.SetDaySpeed(0);
        tide.lowerTide();
    }

    private void OnTriggerExit(Collider col)
    {
        tide.SetDaySpeed(0);
        tide.raiseTide();
    }
}
