using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class flyingStateMachine : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform childObject;
    [SerializeField] wildlifeStates currentState;

    [Header("Navigation")]
    [SerializeField] float navDistance;
    [SerializeField] Transform[] navPoints;
    [SerializeField] int navPointIndex;


    [Header("Wait times")]
    [SerializeField] float maxWait;
    [SerializeField] float currentWait;

    [Header("Flying Stats")]
    [SerializeField] Vector3 moveDirection;
    [SerializeField] float moveSpeed;
    [SerializeField] float moveDistance;
    private Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        childObject = GetComponentInChildren<Transform>();
        startingPosition = childObject.transform.position;
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
                    if (Vector3.Distance(transform.position, navPoints[navPointIndex].position) < navDistance)
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
        navPointIndex = Random.Range(0, navPoints.Length);
        agent.SetDestination(navPoints[navPointIndex].position);
        currentState = wildlifeStates.moving;
    }

    public enum wildlifeStates
    {
        idle,
        moving
    }
}
