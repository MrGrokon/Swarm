using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (listOfPrey.Count < maxPrey)
        {
            int X = (int)Random.Range(minMaxX.x, minMaxX.y);
            int Y = (int)Random.Range(minMaxY.x, minMaxY.y);
            var prey = Instantiate(preyPrefab, new Vector3(X, terrain.transform.position.y + 0.5f, Y), Quaternion.identity);
            listOfPrey.Add(prey);
        }
    }
}
