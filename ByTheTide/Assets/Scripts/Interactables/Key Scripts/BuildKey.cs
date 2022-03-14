using UnityEngine;
using TMPro;

public class BuildKey : MonoBehaviour
{
    [SerializeField]
    GameObject buildKeyText;

    [SerializeField]
    KeyCollecting kc;

    [SerializeField]
    GameObject fullKey;

    private bool nearPlayer = false;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && kc.GetNumKeys() >= 4)
        {
            buildKeyText.SetActive(true);
            nearPlayer = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
            buildKeyText.SetActive(false);
        nearPlayer = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && nearPlayer)
        {
            fullKey.SetActive(true);
            // Play key built SFX here
        }
    }
}
