using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class PreyAiManager : MonoBehaviour
{
    private bool finishedMovementTask = true;

    private NavMeshAgent _nm_Agent;

    [SerializeField] private float roamingDistance;
    void Start()
    {
        _nm_Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (finishedMovementTask)
        {
            SetNewRoamDestination();
        }
        else if (Vector3.Distance(transform.position, _nm_Agent.destination) <= 2f)
        {
            finishedMovementTask = true;
        }
    }

    private void SetNewRoamDestination()
    {
        Vector3 randomDestination = Random.insideUnitSphere * roamingDistance + transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDestination, out hit, roamingDistance, 1);
        _nm_Agent.SetDestination(hit.position);
        finishedMovementTask = false;
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
}
