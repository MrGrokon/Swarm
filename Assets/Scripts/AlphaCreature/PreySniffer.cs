using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreySniffer : MonoBehaviour
{
    public GameObject proof;
    private GameObject target;

    private void GetPrey()
    {
        target = proof.GetComponent<DetectPlayer>().prey;
    }

    private void LateUpdate()
    {
        if (InputTester.inputInstance._playerInputs.Actions.GetPrey.ReadValue<float>() != 0)
        {
            GetPrey();
        }
    }
}
