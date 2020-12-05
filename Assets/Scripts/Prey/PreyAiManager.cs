using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PreyAiManager : MonoBehaviour
{
    private bool finishedMovementTask = true;

    private NavMeshAgent AI;

    [SerializeField] private float roamingDistance;
    // Start is called before the first frame update
    void Start()
    {
        AI = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (finishedMovementTask)
        {
            SetNewRoamDestination();
        }
        else if (Vector3.Distance(transform.position, AI.destination) <= 2f)
        {
            finishedMovementTask = true;
        }
    }

    private void SetNewRoamDestination()
    {
        Vector3 randomDestination = Random.insideUnitSphere * roamingDistance + transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDestination, out hit, roamingDistance, 1);
        AI.SetDestination(hit.position);
        finishedMovementTask = false;
    }
}
