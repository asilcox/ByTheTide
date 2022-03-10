using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionScript : MonoBehaviour
{
    public string LevelToLoad;
    [SerializeField] SaveSystemScript SSS;

    private void Start()
    {
        SSS = SSS.GetComponent<SaveSystemScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SSS.SaveHubLocation();
            SceneManager.LoadScene(LevelToLoad);
        }
    }
}
