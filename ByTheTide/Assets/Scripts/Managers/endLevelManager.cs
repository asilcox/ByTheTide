using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endLevelManager : MonoBehaviour
{
    [SerializeField] string nextLevelName;
    
    private void LoadLevelWait()
    {
        SceneManager.LoadScene(nextLevelName);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("A player is here");
        if(other.gameObject.tag == "Player")
        {
            Invoke("LoadLevelWait", .05f);
        }
    }
}
