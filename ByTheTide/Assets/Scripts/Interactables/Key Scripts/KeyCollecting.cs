using UnityEngine;
using TMPro;

public class KeyCollecting : MonoBehaviour
{
    private int numKeys;

    [SerializeField]
    TextMeshProUGUI mText;

    public int GetNumKeys()
    {
        return numKeys;
    }

    public void IncrementKeys()
    {
        numKeys++;
        Debug.Log(numKeys);
    }

    private void Update()
    {
        mText.SetText("Keys Pieces: " + GetNumKeys());
    }
}
