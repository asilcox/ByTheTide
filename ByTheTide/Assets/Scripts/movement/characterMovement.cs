using UnityEngine;

public class characterMovement : MonoBehaviour
{
    private CharacterController myController;
    private respawnManager rSpawner;
    [Header("Speeds and forces")]
    [SerializeField] float gravity;
    [SerializeField] float movementSpeed;
    [SerializeField] Vector3 velocity;
    [SerializeField] float jumpHeight;

    [Header("Inputs")]
    [SerializeField] private float z;
    [SerializeField] private float x;

    [Header("Ground Checks")]
    [SerializeField] float groundDistance;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform lastPos;
    [SerializeField] bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<CharacterController>(); //Get controller on obj
        rSpawner = GameObject.FindObjectOfType<respawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gravityCheck();
        groundCheck();
        inputCheck();
        movementIn();

        //Jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //lastPos check
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit rHit;
        if (Physics.Raycast(ray, out rHit, groundMask))
        {
            lastPos = rHit.transform;
        }
    }
    public void movementIn()
    {
        Vector3 move = transform.right * x + transform.forward * z; //Get movement directions

        myController.Move(move * movementSpeed * Time.deltaTime); //Apply movement * movement speed
    }
    public void gravityCheck()
    {
        velocity.y += gravity * Time.deltaTime;

        myController.Move(velocity * Time.deltaTime); //Apply gravity
    }

    public void inputCheck()
    {
        x = Input.GetAxis("Horizontal"); //Hor movement keys
        z = Input.GetAxis("Vertical"); //Ver movement keys
    }
    public void groundCheck()
    {
        isGrounded = Physics.Raycast(transform.position, -transform.up, groundDistance, groundMask); //isGrounded raycast

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = gravity; //Apply gravity for falling
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<deathFloor>())
        {
            rSpawner.resetPlayer(lastPos, this.gameObject);
        }
    }

}
