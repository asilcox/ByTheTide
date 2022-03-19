using UnityEngine;
using UnityEngine.SceneManagement;
public class endLevelManager : MonoBehaviour
{
    [SerializeField] string nextLevelName;

    private Scene scene;

    private void LoadLevelWait()
    {
        SceneManager.LoadScene(nextLevelName);
    }

    private void OnTriggerEnter(Collider other)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "churchysTestLevel")
        {
            Debug.Log("In this scene");
            if (GameManager.instance.builtKey == true)
            {
                Debug.Log("Key?");
                if (other.gameObject.tag == "Player")
                {
                    Invoke("LoadLevelWait", .05f);
                }
            }
        }
        if (scene.name != "churchysTestLevel")
        {
            if (other.gameObject.tag == "Player")
            {
                Invoke("LoadLevelWait", .05f);
            }
        }
    }
}
