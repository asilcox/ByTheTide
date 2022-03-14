using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField]
    private KeyCollecting kc;
    private void OnTriggerEnter(Collider col) 
    {
        if (col.tag == "Player")
        {
            // Play key collecting SFX here
            kc.IncrementKeys();
            gameObject.SetActive(false);
        }
    }
}
