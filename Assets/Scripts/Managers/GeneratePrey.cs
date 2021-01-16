using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class GeneratePrey : MonoBehaviour
{

    [SerializeField] private GameObject terrain;

    [SerializeField] private Vector2 minMaxX;

    [SerializeField] private Vector2 minMaxY;

    [SerializeField] private int maxPrey;

    [SerializeField] public List<GameObject> listOfPrey;

    [SerializeField] private GameObject preyPrefab;


    // Update is called once per frame
    void Update()
    {
        if (listOfPrey.Count < maxPrey)  //Génération des proies
        {
            float X = Random.Range(minMaxX.x, minMaxX.y);
            float Y = Random.Range(minMaxY.x, minMaxY.y);
            NavMeshHit hit;
            NavMesh.SamplePosition(transform.position + new Vector3(X,terrain.transform.position.y, Y), out hit, 200f, NavMesh.AllAreas); //Sample la position donnée sur le navmesh et peut retourner un bool
            var prey = Instantiate(preyPrefab, hit.position, Quaternion.identity);
            listOfPrey.Add(prey);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position - new Vector3(minMaxX.x,0, minMaxY.y), 1f);
        Gizmos.DrawSphere(transform.position - new Vector3(minMaxX.y,0, minMaxY.y), 1f);
        Gizmos.DrawSphere( transform.position - new Vector3(minMaxX.x,0, minMaxY.x), 1f);
        Gizmos.DrawSphere(transform.position - new Vector3(minMaxX.y,0, minMaxY.x), 1f);
    }
}
