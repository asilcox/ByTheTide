using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField]
    private KeyCollecting kc;
    private void OnTriggerEnter(Collider col) 
    {
        if (col.tag == "Player")
        {
            
            audioManager.instance.KeySound();
            kc.IncrementKeys();
            gameObject.SetActive(false);
        }
    }
}
