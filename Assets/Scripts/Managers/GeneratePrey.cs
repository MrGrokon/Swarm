using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeneratePrey : MonoBehaviour
{

    [SerializeField] private GameObject terrain;

    private Vector2 minMaxX;

    private Vector2 minMaxY;

    [SerializeField] private int maxPrey;

    [SerializeField] public List<GameObject> listOfPrey;

    [SerializeField] private GameObject preyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        minMaxX = new Vector2(-terrain.transform.localScale.x, terrain.transform.localScale.x);
        minMaxY = new Vector2(-terrain.transform.localScale.z, terrain.transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (listOfPrey.Count < maxPrey)  //Génération des proies
        {
            Vector3 randomSpawnPosition = Random.insideUnitSphere * 200f;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomSpawnPosition, out hit, 200f, NavMesh.AllAreas); //Sample la position donnée sur le navmesh et peut retourner un bool
            var prey = Instantiate(preyPrefab, hit.position, Quaternion.identity);
            listOfPrey.Add(prey);
        }
    }
}
