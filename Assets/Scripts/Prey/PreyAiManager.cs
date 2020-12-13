using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class PreyAiManager : MonoBehaviour
{
    [SerializeField] private bool finishedMovementTask = true;

    private NavMeshAgent _nm_Agent;

    public enum States
    {
        Roam,
        Flee
    }

    [SerializeField] private States aiState;

    [SerializeField] private float roamingDistance;
    [SerializeField] private float fleeDistance;
    [SerializeField] private float fleeMagnitude;

    private bool seePlayer;
    [SerializeField] private float fleeTime;
    [SerializeField] private float maxFleeTime;

    private AiDetection myDetector;
    void Start()
    {
        _nm_Agent = GetComponent<NavMeshAgent>();
        myDetector = GetComponent<AiDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, (Objects.Instance.Alpha.transform.position - transform.position)*-1, Color.blue);
        if (Vector3.Distance(transform.position, _nm_Agent.destination) <= 2f)
        {
            finishedMovementTask = true;
        }
        UpdateStates();

        if (myDetector.FindVisibleTargets())
        {
            seePlayer = true;
            finishedMovementTask = true;
            switchStates(States.Flee);
            fleeTime = maxFleeTime;
        }
        ManageTimer();
    }

    private void SetNewRoamDestination()
    {
        if (finishedMovementTask)
        {
            Vector3 randomDestination = Random.insideUnitSphere * roamingDistance + transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDestination, out hit, roamingDistance, 1);
            _nm_Agent.SetDestination(hit.position);
            finishedMovementTask = false;
        }
    }

    public void Die()
    {
        foreach (var track in GetComponent<TracksCreatorOverTime>().PreyTracks)
        {
            Destroy(track);
        }

        GetComponent<TracksCreatorOverTime>().PreyTracks.Clear();
        Destroy(gameObject);
    }

    private void Flee()
    {
        if (finishedMovementTask)
        {
            Vector3 oppositeDirection = (Objects.Instance.Alpha.transform.position - transform.position)*-1;
            Vector3 fleePosition = oppositeDirection * fleeMagnitude;
            transform.LookAt(fleePosition);
            NavMeshHit hit;
            if (NavMesh.SamplePosition(fleePosition, out hit, fleeDistance, 1))
            {
                NavMesh.SamplePosition(fleePosition, out hit, fleeDistance, 1);
            }
            else
            {
                Vector3 randomDestination = Random.insideUnitSphere * fleeDistance + transform.position;
                NavMesh.SamplePosition(randomDestination, out hit, roamingDistance, 1);
            }
            _nm_Agent.SetDestination(hit.position);
            finishedMovementTask = false; 
        }
    }

    private void UpdateStates()
    {
        switch (aiState)
        {
            case States.Roam:
                    SetNewRoamDestination(); 
                break;
            case States.Flee:
                    Flee();
                break;
        }
    }

    private void switchStates(States newState)
    {
        aiState = newState;
    }

    private void ManageTimer()
    {
        if(fleeTime > 0 && aiState == States.Flee)
            fleeTime -= 1 * Time.deltaTime;
        else if(fleeTime <= 0 && aiState == States.Flee)
        {
            seePlayer = false;
            finishedMovementTask = true;
            switchStates(States.Roam);
        }
    }
}
