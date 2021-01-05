using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.AI;

public class herdManager : PreyAiManager
{
    [Header("Personal Parameters")]
    [SerializeField] private float herdAreaRadius;
    [SerializeField] private int startingHerdSize;
    [SerializeField] private GameObject preyToInstantiate;
    [SerializeField] private List<GameObject> herdPrey;
    [SerializeField] private GameObject herdPositionPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= startingHerdSize; i++)
        {
            Vector2 startPosition = Random.insideUnitCircle * herdAreaRadius;
            var prey = Instantiate(preyToInstantiate,
                new Vector3(startPosition.x, this.transform.position.y, startPosition.y), Quaternion.identity);
            var manager = prey.GetComponent(typeof(PreyAiManager)) as PreyAiManager;
            var positionRef = Instantiate(herdPositionPrefab,
                new Vector3(startPosition.x, this.transform.position.y, startPosition.y), Quaternion.identity);
            positionRef.transform.SetParent(this.transform);
            manager.fixedDestination = positionRef.transform;
            herdPrey.Add(prey);
        }
    }

    private void Update()
    {
        if (_nm_Agent.remainingDistance <= ReachingDistance)
        {
            Debug.Log("Prey reached his destination");
            //Do things when i reach my Position
            switch (MyState)
            {
                case PreyStates.Roam:
                    //TODO: générer proproment un nouveau point de roaming, si possible non randomS
                    _nm_Agent.SetDestination(GetRandomRoamingPosition());
                    ChangeState(PreyStates.Roam);
                    break;
            }
        }
    }
    
    private Vector3 GetRandomRoamingPosition(){
        //TODO: get a random position on the walkable NavMesh
        Vector3 _randomPos = Random.insideUnitSphere * 10f + this.transform.position;
        NavMeshHit _hit;
        NavMesh.SamplePosition(_randomPos, out _hit, Mathf.Infinity, 1); // 1 == au mask d'area Walkable du navMash
        return _hit.position;
    
    }
    public void ChangeState(PreyStates _state){
        if(MyState != _state){
            Debug.Log("ChangeState to " + _state);
            MyState = _state;
            //Change_NMA_Properties(_state);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!herdPrey.Contains(other.gameObject))
        {
            herdPrey.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (herdPrey.Contains(other.gameObject))
        {
            herdPrey.Remove(other.gameObject);
        }
    }
}
