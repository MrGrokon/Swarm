using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject preyPrefab;

    

    public void Spawn()
    {
        Instantiate(preyPrefab, this.transform.position, Quaternion.identity);
    }
}
