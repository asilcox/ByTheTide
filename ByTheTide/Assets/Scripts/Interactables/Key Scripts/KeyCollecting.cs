using TMPro;
using UnityEngine;

public class KeyCollecting : MonoBehaviour
{
    private int numKeys;
    public int collectableKeys;
    [SerializeField] GameObject endObj;
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
        if (collectableKeys == numKeys)
        {
            mText.text = "All key parts collected, Get to the boat!";
            endObj.SetActive(true);
        }
        else
        {
            mText.SetText("Keys Pieces: " + GetNumKeys());
        }

    }
}
