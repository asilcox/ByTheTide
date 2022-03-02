using UnityEngine;

public class dayNightScaler : MonoBehaviour
{
    [SerializeField] float nightTimeMax;
    [SerializeField] float currentNightTime;
    [SerializeField] float rotSpeed;
    [SerializeField] Vector3 rotDirection;
    [SerializeField] timeStates currentTimeState;
    [SerializeField] timeStates previousState;
    [SerializeField] Vector3 forwardRotSwitch;
    [SerializeField] Vector3 reverseRotSwitch;
    // Update is called once per frame
    void Update()
    {
        switch (currentTimeState)
        {
            case timeStates.forward:
                {
                    transform.Rotate(rotDirection * rotSpeed * Time.deltaTime);
                    if (transform.eulerAngles.x >= forwardRotSwitch.x)
                    {
                        previousState = timeStates.forward;
                        currentTimeState = timeStates.nightTime;
                    }
                    break;
                }
            case timeStates.reverse:
                {
                    transform.Rotate(-rotDirection * rotSpeed * Time.deltaTime);
                    if (transform.eulerAngles.x <= reverseRotSwitch.x)
                    {
                        previousState = timeStates.reverse;
                        currentTimeState = timeStates.nightTime;
                    }
                    break;
                }
            case timeStates.nightTime:
                {
                    currentNightTime = currentNightTime - 1 * Time.deltaTime;
                    if(currentNightTime <= 0)
                    {
                       if(previousState == timeStates.forward)
                        {
                            currentNightTime = nightTimeMax;
                            currentTimeState = timeStates.reverse;
                        }
                       else
                        {
                            currentNightTime = nightTimeMax;
                            currentTimeState = timeStates.forward;
                        }
                    }
                    break;
                }

        }
    }

    public enum timeStates
    {
        forward,
        reverse,
        nightTime,
    }
}

