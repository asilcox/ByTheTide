using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerStats : MonoBehaviour
{
    [SerializeField] public int livesRemaining;
    [SerializeField] TextMeshProUGUI livesText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = livesRemaining.ToString();
    }

    public void loseLife()
    {
        if (livesRemaining == 1)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene("mainMenu");
        }
        else
        {
            livesRemaining--;
        }

    }
}
