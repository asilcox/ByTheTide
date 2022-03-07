using UnityEngine;

public class dayNightScaler : MonoBehaviour
{
    [SerializeField] float rotSpeed;
    [SerializeField] Vector3 rotDirection;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotDirection * rotSpeed * Time.deltaTime);
    }

}

