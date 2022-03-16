using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField]
    private KeyCollecting kc;

    private void Start()
    {
        Invoke("KeyCheckWait", .05f);
    }

    private void KeyCheckWait()
    {
        if (PlayerPrefs.GetString("Key" + gameObject.name, "false") == "true")
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider col) 
    {
        if (col.tag == "Player")
        {
            
            audioManager.instance.KeySound();
            kc.IncrementKeys();
            PlayerPrefs.SetString("Key" + gameObject.name, "true");
            gameObject.SetActive(false);
        }
    }
}
