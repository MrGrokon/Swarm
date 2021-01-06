using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
    private bool spawned = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Objects.Instance.Alpha && spawned == false)
        {
            GetComponentInParent<Spawner>().Spawn();
            spawned = true;
        }
    }
}
