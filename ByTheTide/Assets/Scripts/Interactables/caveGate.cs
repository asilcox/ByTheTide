using UnityEngine;

public class caveGate : MonoBehaviour
{
    [SerializeField] Vector3 targetPos;
    [SerializeField] Vector3 maxY;
    [SerializeField] private bool gateUnlocked;
    [SerializeField] float speed;
    [SerializeField] GameObject gateObj;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gateUnlocked == true)
        {
            openGate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gateUnlocked = true;
        }
    }

    public void openGate()
    {

        if (gateObj.transform.position.y >= maxY.y)
        {

        }
        else
        {
            gateObj.transform.Translate(targetPos * speed * Time.deltaTime);
        }
    }
}
