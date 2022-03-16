using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class devNavigator : MonoBehaviour
{
    [SerializeField] GameObject devNav;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            if(devNav.activeSelf == false)
            {
                devNav.SetActive(true);
            }
            else
            {
                devNav.SetActive(false);
            }
        }
    }

    public void loadSceneByName(string sceneName)
    {
        devNav.SetActive(false);
        SceneManager.LoadScene(sceneName);
    }
}
