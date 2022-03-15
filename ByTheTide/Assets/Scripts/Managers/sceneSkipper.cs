using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneSkipper : MonoBehaviour
{
    private sceneSkipper skipper;

    private void Awake()
    {
        #region
        if (skipper == null)
        {
            skipper = this;
            DontDestroyOnLoad(this);
        }
        else if (skipper != this)
        {
            Destroy(gameObject);
        }
        #endregion
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            var thisSceneInd = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(thisSceneInd + 1);
        }
    }
}
