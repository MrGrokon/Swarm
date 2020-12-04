using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackOrderer : MonoBehaviour
{
    public enum formation
    {
        Triangle,
        Round
    };

    [SerializeField] private formation myFormation;

    private void Update()
    {
        if(InputTester.inputInstance.formationAxis != Vector2.zero)
            SetFormation("test", myFormation, InputTester.inputInstance.formationAxis);
    }

    public void SetFormation(string str, formation _formation, Vector2 formationAxis)
    {
        
    }
}
