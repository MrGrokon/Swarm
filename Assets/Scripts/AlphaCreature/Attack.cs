using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private List<GameObject> PreyInTrigger;
    // Update is called once per frame
    void Update()
    {
        if (InputTester.inputInstance._playerInputs.Actions.Attack.triggered)
        {
            foreach (var obj in PreyInTrigger)
            {
                Destroy(obj);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Prey"))
        {
            PreyInTrigger.Add(other.transform.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Prey"))
        {
            PreyInTrigger.Remove(other.transform.gameObject);
        }
    }
}
