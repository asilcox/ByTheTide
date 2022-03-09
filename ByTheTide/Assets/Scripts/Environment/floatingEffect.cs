using UnityEngine;

public class floatingEffect : MonoBehaviour
{
    [SerializeField] Vector3 moveDirection;
    [SerializeField] float moveSpeed;
    [SerializeField] float moveDistance;
    public float delay;
    private Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = gameObject.transform.position;
        delay = Random.Range(0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (delay > 0)
        {
            delay = delay - 1 * Time.deltaTime;
        }
        else
        {
            transform.position = startingPosition + moveDirection * (moveDistance * Mathf.Sin(Time.time * moveSpeed));
        }

    }
}
