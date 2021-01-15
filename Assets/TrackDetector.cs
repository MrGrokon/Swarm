using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Track"))
        {
            other.gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Track"))
        {
            other.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }
}
