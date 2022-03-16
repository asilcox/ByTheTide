using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class devNavigator : MonoBehaviour
{
    [SerializeField] private devPan devNav;
    // Start is called before the first frame update
    void Start()
    {
        devNav = GameObject.FindObjectOfType<devPan>();
    }

    // Update is called once per frame
    void Update()
    {
        var gameObj = devNav.gameObject;
        if(Input.GetKeyDown(KeyCode.L))
        {
            if(gameObj.activeSelf == false)
            {
                gameObj.SetActive(true);
            }
            else
            {
                gameObj.SetActive(false);
            }
        }
    }

    public void loadSceneByName(string sceneName)
    {
        var gameObj = devNav.gameObject;
        gameObj.SetActive(false);
        SceneManager.LoadScene(sceneName);
    }
}
