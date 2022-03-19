using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneTransitionScript : MonoBehaviour
{
    public string LevelToLoad;
    [SerializeField] SaveSystemScript SSS;

    [SerializeField] TextMeshProUGUI text;
    private bool inRange;

    private void Start()
    {
        SSS = SSS.GetComponent<SaveSystemScript>();
        text.text = string.Empty;
    }

    private void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SSS.SaveHubLocation();
                SceneManager.LoadScene(LevelToLoad);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.text = "Press ''E'' to start level.";
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.text = string.Empty;
            inRange = false;
        }
    }
}
