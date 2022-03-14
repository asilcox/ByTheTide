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

    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (scene.name == "churchysTestLevel")
        {
            if (GameManager.instance.builtKey == true)
            {
                if (other.gameObject.tag == "Player")
                {
                    Invoke("LoadLevelWait", .05f);
                }
            }
        }
        else
        {
            if (other.gameObject.tag == "Player")
            {
                Invoke("LoadLevelWait", .05f);
            }
        }
    }
}
