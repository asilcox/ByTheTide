using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endLevelManager : MonoBehaviour
{
    [SerializeField] string nextLevelName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("hitting a player");
            PlayerPrefs.SetInt("levelsComplete", PlayerPrefs.GetInt("levelsComplete") + 1);
            if(PlayerPrefs.GetInt("levelsComplete") >= 100)
            {
                //End game if all levels are complete
            }
            else
            {
                Debug.Log("hitting a player");
                SceneManager.LoadScene(nextLevelName);
            }
        }
    }
}
