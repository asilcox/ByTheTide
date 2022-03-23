using UnityEngine;

public class WeatherStateMachine : MonoBehaviour
{
    public enum States
    {
        RAIN,
        WIND,
        SUN,
        STORM
    }

    States currentState;

    bool setState;

    public GameObject rainSystem;
    public GameObject windSystem;
    public GameObject hurricane;
    public GameObject lightning;

    private void Start()
    {
        currentState = States.SUN;
        setState = false;
    }

    private void Update()
    {
        if (setState)
        {
            switch (currentState)
            {
                case States.RAIN:
                    Debug.Log("It is raining.");
                    rainSystem.SetActive(true);
                    windSystem.SetActive(false);
                    hurricane.SetActive(false);
                    lightning.SetActive(false);
                    setState = false;
                    break;
                case States.WIND:
                    Debug.Log("It is windy.");
                    rainSystem.SetActive(false);
                    windSystem.SetActive(true);
                    hurricane.SetActive(false);
                    lightning.SetActive(false);
                    setState = false;
                    break;
                case States.SUN:
                    Debug.Log("It is sunny.");
                    rainSystem.SetActive(false);
                    windSystem.SetActive(false);
                    hurricane.SetActive(false);
                    lightning.SetActive(false);
                    setState = false;
                    break;
                case States.STORM:
                    Debug.Log("There's a storm brewing.");
                    rainSystem.SetActive(true);
                    windSystem.SetActive(true);
                    hurricane.SetActive(true);
                    lightning.SetActive(true);
                    setState = false;
                    break;
            }
        }
    }

    public void SetState(States state)
    {
        currentState = state;
        setState = true;
    }
}
