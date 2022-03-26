using UnityEngine;
using UnityEngine.AI;

public class randomPointStateMachine : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] wildlifeStates currentState;
    [Header("Navigation")]
    [SerializeField] float walkRadius;
    [SerializeField] Vector3 newPoint;
    [SerializeField] float navDistance;

    [Header("Wait times")]
    [SerializeField] float maxWait;
    [SerializeField] float currentWait;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case wildlifeStates.idle:
                {
                    agent.isStopped = true;
                    currentWait = currentWait - 1 * Time.deltaTime;
                    if (currentWait <= 0)
                    {
                        setPath();
                    }
                    break;
                }
            case wildlifeStates.moving:
                {
                    agent.isStopped = false;
                    if (Vector3.Distance(transform.position, newPoint) < navDistance)
                    {
                        currentWait = maxWait;
                        currentState = wildlifeStates.idle;
                    }
                    break;
                }
        }

    }

    public void setPath()
    {
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        newPoint = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1))
        {
            newPoint = hit.position;
        }
        else
        {
            setPath();
        }
        agent.SetDestination(newPoint);
        if (agent.hasPath)
        {
            if (agent.pathStatus == NavMeshPathStatus.PathInvalid)
            {
                setPath();
            }
            else
            {
                currentState = wildlifeStates.moving;
            }
        }

    }

    public enum wildlifeStates
    {
        idle,
        moving
    }
}
