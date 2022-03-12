using UnityEngine;

public class characterRotation : MonoBehaviour
{
    [SerializeField] float lookSpeed;
    public float xRotation;
    [SerializeField] Transform playerBody;
    [SerializeField] float mouseX;
    [SerializeField] float mouseY;
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        getInput(); //Get mouse inputs by mose movement axis
        rotateTransform(); //Apply transform to parent model and camera
    }

    public void getInput()
    {
        mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;
    }

    public void rotateTransform()
    {
        playerBody.Rotate(Vector3.up * mouseX);
        xRotation -= mouseY;
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        xRotation = Mathf.Clamp(xRotation, -90, 90);
    }
}
