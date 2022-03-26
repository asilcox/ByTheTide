using TMPro;
using UnityEngine;

public class KeyCollecting : MonoBehaviour
{
    private int numKeys;
    public int collectableKeys;
    [SerializeField] GameObject endObj;
    [SerializeField]
    TextMeshProUGUI mText;
    public GameObject[] keyHUD;

    private void Start()
    {
        numKeys = PlayerPrefs.GetInt("CurIndex", numKeys);
    }

    public int GetNumKeys()
    {
        return numKeys;
    }

    public void IncrementKeys()
    {
        numKeys++;
        PlayerPrefs.SetInt("CurIndex", numKeys);
        Debug.Log(numKeys);
    }

    private void Update()
    {
        switch (numKeys)
        {
            case 0:
                break;
            case 1:
                keyHUD[0].SetActive(true);
                break;
            case 2:
                keyHUD[1].SetActive(true);
                break;
            case 3:
                keyHUD[2].SetActive(true);
                break;
            case 4:
                keyHUD[3].SetActive(true);
                break;

        }
        if (collectableKeys == numKeys)
        {
            mText.text = "All key parts collected, Go build the Key";
            
        }
        else
        {
            mText.SetText("Keys Pieces: " + GetNumKeys());
        }

    }


}
