using UnityEngine;

public class WeatherChangerTest : MonoBehaviour
{
    public WeatherStateMachine wsm;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            wsm.SetState(WeatherStateMachine.States.RAIN);
        if (Input.GetKeyDown(KeyCode.W))
            wsm.SetState(WeatherStateMachine.States.WIND);
        if (Input.GetKeyDown(KeyCode.E))
            wsm.SetState(WeatherStateMachine.States.SUN);
        if (Input.GetKeyDown(KeyCode.R))
            wsm.SetState(WeatherStateMachine.States.STORM);
    }
}
