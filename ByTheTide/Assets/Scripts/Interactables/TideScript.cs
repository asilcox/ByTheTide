using UnityEngine;

public class TideScript : MonoBehaviour
{
    bool isHighTide = false;

    [SerializeField]
    float maxHeight = 5.0f;

    [SerializeField]
    float minHeight = 0.0f;

    [SerializeField]
    float tideSpeed = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isHighTide)
        {
            isHighTide = false;
            Debug.Log(isHighTide);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isHighTide)
        {
            isHighTide = true;
            Debug.Log(isHighTide);
        }

        if (isHighTide && transform.position.y < maxHeight)
            transform.position += new Vector3(0.0f, tideSpeed * Time.deltaTime, 0.0f);
        if (!isHighTide && transform.position.y > minHeight)
            transform.position -= new Vector3(0.0f, tideSpeed * Time.deltaTime, 0.0f);
    }

    public void SetHighTide(bool ht)
    {
        isHighTide = ht;
    }

    public bool GetHighTide()
    {
        return isHighTide;
    }
}
