using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaCreature_Creator : MonoBehaviour
{
    [SerializeField] private float CreatureCost;

    private void Update()
    {
        if(InputTester.inputInstance._playerInputs.Actions.CreateBeta.triggered) //Inclure également le cout de la création dans le if
            CreateBeta();
    }

    private void CreateBeta()
    {
        
    }
}
