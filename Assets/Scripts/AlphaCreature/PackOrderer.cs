using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackOrderere : MonoBehaviour
{
    public enum formation
    {
        Triangle,
        Round
    };

    [SerializeField] private formation myFormation;

    private void Update()
    {
        /*if()
        SetFormation("test", myFormation);*/
    }

    public void SetFormation(string str, formation _formation)
    {
        
    }
}
