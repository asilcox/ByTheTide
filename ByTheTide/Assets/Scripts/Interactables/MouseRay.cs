using UnityEngine;

public class MouseRay : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    [SerializeField]
    TideScript tide;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                tide.SetHighTide(!tide.GetHighTide());

            }
        }
    }
}
